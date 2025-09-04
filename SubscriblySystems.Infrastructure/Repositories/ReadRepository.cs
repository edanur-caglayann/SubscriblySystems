using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using subscriblySystem.Domain.Models;
using subscriblySystem.Infrastructure.Context;
using SubscriblySystems.Aplication.Repositories;

namespace SubscriblySystems.Infrastructure.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;

    public ReadRepository(AppDbContext context)
    {
        _context = context;
    }
    
    // dbcontexte yani veritabanina baglanan nesneye erisip bu nesneye bir entity veriyoruz
    // onu set ettiginde artik bu tabloyu dsorgulayabilir, ekleyebilir silebilir guncelleybilriiz
    // table diyerek de her seferinde _context.Set<T>(); yazmaya gerek olmuyor
    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        if(!tracking)
            query = query.AsNoTracking();
        return query;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if(!tracking)
            query = query.AsNoTracking();
        return query.Where(filter);
    }

    public Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if(!tracking)
            query = query.AsNoTracking();
        return query.FirstOrDefaultAsync(filter);
    }

    public async Task<T> GetByIdAsync(Guid id, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if(!tracking)
            query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(data => data.Id == id);
    }

    public IQueryable<T> GetUserWithBoard(Expression<Func<T, bool>> filter = null,
        params Expression<Func<T, object>>[] includeProperties)
    {
        var query = Table.AsQueryable().AsNoTracking();
        
        if(filter != null) query = query.Where(filter); // filtre verildgiyse uygula
        if (includeProperties != null)
        {
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
        }

        return query;
    }
}