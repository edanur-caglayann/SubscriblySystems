using subscriblySystem.Domain.Entities;
using subscriblySystem.Domain.Enum;
using subscriblySystem.Domain.Models;
namespace SubscriblySystem.Domain.Entities;

public class BillPaymentHistory : BaseEntity
{
    public Guid BillId { get; set; }
    public BillStatus Status { get; set; }
    public Guid PaidUserId { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    
    public Bill Bill { get; set; } // bir faturanin birden fazla gecmisi one to many
    // navigation property -> nesneler arasi iliskiyi kod tarafinda kullanmamizi saglar
    public User PaidUser { get; set; } // odeme yapan kisi (fluent api kullanılması gerekebilir)
}