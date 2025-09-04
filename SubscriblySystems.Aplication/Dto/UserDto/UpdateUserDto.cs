namespace SubscriblySystems.Aplication.Dto.UserDto;

public class UpdateUserDto
{
    public required string UserName { get; init; }
    public required string UserSurname { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string PhoneNumber { get; init; }
    public required string ProfileImage { get; init; }
    
}