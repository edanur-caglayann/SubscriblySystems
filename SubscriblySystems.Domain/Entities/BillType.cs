using SubscriblySystem.Domain.Entities;
using subscriblySystem.Domain.Models;

namespace subscriblySystem.Domain.Entities;

public class BillType : BaseEntity
{
    public string BillName { get; set; }
    public string description { get; set; }

    public ICollection<Bill> Bills { get; set; } = new List<Bill>(); // o fatura tipinde birden fazla fatura olabilir one to many
}