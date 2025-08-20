using subscriblySystem.Domain.Entities;
using subscriblySystem.Domain.Models;

namespace SubscriblySystem.Domain.Entities;

public class Bill : BaseEntity
{
    public Guid BoardId { get; set; }
    public Guid UserId { get; set; }
    public Guid BillTypeId { get; set; }
    public decimal BillAmount { get; set; }
    public DateTime LastPaymentDate { get; set; }
    public bool IsRecurring { get; set; }
    
    public Board Boards { get; set; } // one to many
    public User Users { get; set; }
    public BillType BillTypes { get; set; } // one to many
    public ICollection<BillPaymentHistory> BillPaymentHistories { get; set; } = new List<BillPaymentHistory>();
}