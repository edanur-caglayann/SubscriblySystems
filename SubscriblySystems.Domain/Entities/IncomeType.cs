using subscriblySystem.Domain.Models;

namespace subscriblySystem.Domain.Entities;

public class IncomeType : BaseEntity
{
    public string IncomeName { get; set; }
    public string description { get; set; }
    
    public ICollection<Income> Incomes { get; set; } = new List<Income>(); 
    // o tipte gelirden birden fazla olabilir
}