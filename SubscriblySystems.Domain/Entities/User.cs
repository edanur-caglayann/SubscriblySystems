using subscriblySystem.Domain.Models;

namespace subscriblySystem.Domain.Entities;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string PhoneNumber { get; set; }
    public string ProfileImage { get; set; }

    public ICollection<Income> Incomes { get; set; } = new List<Income>(); // bir kullanicnin birden fazla geliri one to many
    public ICollection<Board> Board { get; set; } = new List<Board>(); // bir kullanici birden fazla pano da olabilri many to many
}