using AuthDemo.Domain.Constants;
using AuthDemo.Domain.Dtos.Auth;
using AuthDemo.Domain.Entities;

namespace AuthDemo.Application.Mapping;

public static class DtoToEntityMappingExtensions
{
    public static UserEntity Map(this RegisterUserRequestDto requestDto)
    {
        return new UserEntity(requestDto.FirstName,
            requestDto.LastName,
            requestDto.Email,
            Regions.B_GAME,
            requestDto.Email,
            requestDto.Email,
            DateTime.UtcNow,
            null,
            null,
            false);
    }
}