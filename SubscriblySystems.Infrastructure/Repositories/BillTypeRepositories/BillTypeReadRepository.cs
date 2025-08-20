using subscriblySystem.Domain.Entities;
using subscriblySystem.Infrastructure.Context;
using SubscriblySystems.Aplication.Repositories.BillTypeRepositories;

namespace SubscriblySystems.Infrastructure.Repositories.BillTypeRepositories;

public class BillTypeReadRepository: ReadRepository<BillType>, IBillTypeReadRepository
{
    public BillTypeReadRepository(AppDbContext context) : base(context)
    {
    }
}