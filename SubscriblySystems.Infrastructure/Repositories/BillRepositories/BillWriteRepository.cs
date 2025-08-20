using SubscriblySystem.Domain.Entities;
using subscriblySystem.Infrastructure.Context;
using SubscriblySystems.Aplication.Repositories.BillRepositories;

namespace SubscriblySystems.Infrastructure.Repositories.BillRepositories;

public class BillWriteRepository : WriteRepository<Bill>, IBillWriteRepository
{
    public BillWriteRepository(AppDbContext context) : base(context)
    {
    }
}