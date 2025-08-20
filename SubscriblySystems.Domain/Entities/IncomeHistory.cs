using subscriblySystem.Domain.Models;

namespace subscriblySystem.Domain.Entities;

public class IncomeHistory : BaseEntity
{
    public Guid UserId { get; set; }
    public decimal Amount { get; set; }
    public DateTime EffectiveDate { get; set; }
    
    public User User { get; set; }
    public Income Income { get; set; } // one to many
}