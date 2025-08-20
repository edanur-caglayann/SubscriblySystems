using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using subscriblySystem.Domain.Entities;
using SubscriblySystem.Domain.Entities;
using subscriblySystem.Domain.Models;

namespace subscriblySystem.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) {}
    
    // Entity - Db Tablolari iliskisi
    public DbSet<User> Users { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Income> Incomes { get; set; }
    public DbSet<Board> Boards { get; set; }
    public DbSet<BillPaymentHistory> BillPaymentHistories { get; set; }
    public DbSet<BillType> BillTypes { get; set; }
    public DbSet<IncomeHistory> IncomeHistories { get; set; }
    public DbSet<IncomeType> IncomeTypes { get; set; }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = DateTime.Now;
                entry.Entity.IsActive = true; // yeni kayitlar aktif olsun
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedDate = DateTime.UtcNow;
            }
            
        }
        return base.SaveChanges();
    }
}


 