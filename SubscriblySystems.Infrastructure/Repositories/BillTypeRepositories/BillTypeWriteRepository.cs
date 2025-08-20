using subscriblySystem.Domain.Entities;
using subscriblySystem.Infrastructure.Context;
using SubscriblySystems.Aplication.Repositories.BillTypeRepositories;

namespace SubscriblySystems.Infrastructure.Repositories.BillTypeRepositories;

public class BillTypeWriteRepository: WriteRepository<BillType>, IBillTypeWriteRepository
{
    public BillTypeWriteRepository(AppDbContext context) : base(context)
    {
    }
}