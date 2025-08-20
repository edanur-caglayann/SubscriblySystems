using subscriblySystem.Domain.Entities;
using subscriblySystem.Infrastructure.Context;
using SubscriblySystems.Aplication.Repositories.IncomeTypeRepositories;

namespace SubscriblySystems.Infrastructure.Repositories.IncomeTypeRepositories;

public class IncomeTypeReadRepository : ReadRepository<IncomeType>, IIncomeTypeReadRepository
{
    public IncomeTypeReadRepository(AppDbContext context) : base(context)
    {
    }
}