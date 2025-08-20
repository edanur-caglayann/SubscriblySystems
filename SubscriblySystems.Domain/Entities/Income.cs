using subscriblySystem.Domain.Models;

namespace subscriblySystem.Domain.Entities;

public class Income : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid IncomeTypeId { get; set; }
    public decimal IncomeAmount { get; set; }

    public User User { get; set; } // one to many
    public IncomeType IncomeType { get; set; } // one to many
    
}