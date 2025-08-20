using SubscriblySystem.Domain.Entities;
using subscriblySystem.Domain.Enum;
using subscriblySystem.Domain.Models;

namespace subscriblySystem.Domain.Entities;

public class Board : BaseEntity
{
    public string BoardName { get; set; }
    public string description { get; set; }
    public BoardTypeEnum BoardType { get; set; }

    public ICollection<Bill> Bills { get; set; } = new List<Bill>(); // bir pano birden fazla fatura  one to many
    public ICollection<User> Users { get; set; } = new List<User>(); // many to many

}