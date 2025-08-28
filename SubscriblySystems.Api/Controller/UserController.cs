using Microsoft.AspNetCore.Mvc;
using SubscriblySystems.Api.Dto;
using SubscriblySystems.Aplication.Dto;
using SubscriblySystems.Aplication.Services.UserService;

namespace SubscriblySystems.Api.Controller;

[ApiController]
[Route("api/user")]
public class UserController(UserService userService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto createUser)
    {
        //Validation
        if(createUser == null)
            throw new ArgumentNullException(nameof(createUser));
        
        var response = await userService.CreateUser(new CreateUserDto
        {
            UserName = createUser.UserName,
            UserSurname = createUser.UserSurname,
            Email = createUser.Email,
            Password = createUser.Password,
            PhoneNumber = createUser.PhoneNumber,
            ProfileImage = createUser.ProfileImage
        });

        if (response == true)
            return Ok("Kullanıcı başarıyla oluşturuldu");

        else
        {
            return BadRequest("Kullanıcı oluşturulurken hata oluştu");
        }
    }
    
    
}
