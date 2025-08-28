namespace SubscriblySystems.Aplication.Dto;

public class CreateUserDto
{
    public required string UserName { get; init; }
    public required string UserSurname { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string PhoneNumber { get; init; }
    public required string ProfileImage { get; init; }
}