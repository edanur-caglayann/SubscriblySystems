using subscriblySystem.Domain.Entities;
using subscriblySystem.Infrastructure.Context;
using SubscriblySystems.Aplication.Repositories.IncomeRepositories;

namespace SubscriblySystems.Infrastructure.Repositories.IncomeRepositories;

public class IncomeReadRepository : ReadRepository<Income>, IIncomeReadRepository
{
    public IncomeReadRepository(AppDbContext context) : base(context)
    {
    }
}