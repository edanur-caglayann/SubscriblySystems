using SubscriblySystem.Domain.Entities;
using subscriblySystem.Infrastructure.Context;
using SubscriblySystems.Aplication.Repositories.BillPaymentHistoryRepositories;

namespace SubscriblySystems.Infrastructure.Repositories.BillPaymentHistoryRepositories;

public class BillPaymentHistoryWriteRepository : WriteRepository<BillPaymentHistory>, IBillPaymentHistoryWriteRepository
{
    public BillPaymentHistoryWriteRepository(AppDbContext context) : base(context)
    {
    }
}