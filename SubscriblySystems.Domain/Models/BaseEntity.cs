namespace subscriblySystem.Domain.Models;

public abstract class BaseEntity
{
    public Guid Id {get; set;}
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate {get; set;} = DateTime.UtcNow;
    public int Rank {get; set;} 
    public bool IsActive {get; set;}
}