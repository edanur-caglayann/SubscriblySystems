using subscriblySystem.Domain.Entities;
using subscriblySystem.Infrastructure.Context;
using SubscriblySystems.Aplication.Repositories.IncomeHistoryRepositories;

namespace SubscriblySystems.Infrastructure.Repositories.IncomeHistoryRepositories;

public class IncomeHistoryWriteRepository : WriteRepository<IncomeHistory>, IIncomeHistoryWriteRepository
{
    public IncomeHistoryWriteRepository(AppDbContext context) : base(context)
    {
    }
}