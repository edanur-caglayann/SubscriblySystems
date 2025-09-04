using AutoMapper;
using SubscriblySystems.Api.Dto;
using SubscriblySystems.Aplication.Dto;
using SubscriblySystems.Aplication.Dto.UserDto;

namespace SubscriblySystems.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DeleteUserRequestDto, DeleteUserDto>();
        CreateMap<UpdateUserRequestDto, UpdateUserDto>();
    }
}