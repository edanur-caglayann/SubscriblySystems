using subscriblySystem.Domain.Entities;
using subscriblySystem.Infrastructure.Context;
using SubscriblySystems.Aplication.Repositories.IncomeTypeRepositories;

namespace SubscriblySystems.Infrastructure.Repositories.IncomeRepositories;

public class IncomeWriteRepository : WriteRepository<IncomeType>, IIncomeTypeWriteRepository
{
    public IncomeWriteRepository(AppDbContext context) : base(context)
    {
    }
}