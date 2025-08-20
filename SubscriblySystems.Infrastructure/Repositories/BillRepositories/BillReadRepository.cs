using SubscriblySystem.Domain.Entities;
using subscriblySystem.Infrastructure.Context;
using SubscriblySystems.Aplication.Repositories.BillRepositories;

namespace SubscriblySystems.Infrastructure.Repositories.BillRepositories;

public class BillReadRepository : ReadRepository<Bill>, IBillReadRepository
{
    public BillReadRepository(AppDbContext context) : base(context)
    {
    }
}