using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubscriblySystems.Api.Dto;
using SubscriblySystems.Aplication.Dto;
using SubscriblySystems.Aplication.Dto.UserDto;
using SubscriblySystems.Aplication.Services.UserService;

namespace SubscriblySystems.Api.Controller;

[ApiController]
[Route("api/user")]
public class UserController(UserService userService, Mapper mapper) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto createUser)
    {
        //validation
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
            return Ok("Kullanici basariyla olusturuldu");
        else
        {
            return BadRequest("Kullanıcı oluşturulurken hata oluştu");
        }
    }
    
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequestDto deleteUserRequestDto)
    {
        if(deleteUserRequestDto == null) throw new ArgumentNullException(nameof(deleteUserRequestDto));

        var dto = mapper.Map<DeleteUserDto>(deleteUserRequestDto);
        var deleteResponse = await userService.DeleteUser(dto);

        if (deleteResponse == true) return Ok();
        else return BadRequest("Kullanici silinemedi");

    }
    
    [HttpPut("update")]
    public async Task<bool> UpdateUser([FromBody] UpdateUserRequestDto updateUserRequestDto, [FromBody] string id)
    {
        if(updateUserRequestDto == null) throw new ArgumentNullException(nameof(updateUserRequestDto));
        if(id == null) throw new ArgumentNullException(nameof(id));
        
        // bir nesneyi diger nesneye donusturmek icin  mapping kullandik
        var dto = mapper.Map<UpdateUserDto>(updateUserRequestDto);
        
        var updateResponse = await userService.UpdateUser(dto,id);
        return updateResponse;
    }
  
    
    
}