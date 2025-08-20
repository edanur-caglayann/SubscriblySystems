using SubscriblySystem.Domain.Entities;
using subscriblySystem.Infrastructure.Context;
using SubscriblySystems.Aplication.Repositories.BillPaymentHistoryRepositories;

namespace SubscriblySystems.Infrastructure.Repositories.BillPaymentHistoryRepositories;

public class BillPaymentHistoryReadRepository : ReadRepository<BillPaymentHistory>, IBillPaymentHistoryReadRepository
{
    public BillPaymentHistoryReadRepository(AppDbContext context) : base(context)
    {
    }
}