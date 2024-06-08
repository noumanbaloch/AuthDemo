using AuthDemo.Domain.Dtos.Auth;
using AuthDemo.Domain.Entities;

namespace AuthDemo.Application.Mapping;

public static class EntityToDtoMappingExtensions
{
    public static LoginUserResponseDto Map(this UserEntity entity, string token)
    {
        return new LoginUserResponseDto(entity.Email!,
            entity.FirstName,
            entity.LastName,
            entity.Region,
            token);
    }
}