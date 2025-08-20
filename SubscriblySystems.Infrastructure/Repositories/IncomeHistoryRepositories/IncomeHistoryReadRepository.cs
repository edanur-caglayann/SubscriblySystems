using subscriblySystem.Domain.Entities;
using subscriblySystem.Infrastructure.Context;
using SubscriblySystems.Aplication.Repositories.IncomeHistoryRepositories;

namespace SubscriblySystems.Infrastructure.Repositories.IncomeHistoryRepositories;

public class IncomeHistoryReadRepository : ReadRepository<IncomeHistory>, IIncomeHistoryReadRepository
{
    public IncomeHistoryReadRepository(AppDbContext context) : base(context)
    {
    }
}