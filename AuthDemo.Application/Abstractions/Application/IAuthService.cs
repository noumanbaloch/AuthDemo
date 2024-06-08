using AuthDemo.Domain.Dtos.Auth;
using AuthDemo.Domain.GenericResponse;

namespace AuthDemo.Application.Abstractions.Application;
public interface IAuthService
{
    Task<GenericResponse<RegisterUserResponseDto>> RegisterUserAsync(RegisterUserRequestDto requestDto);

    Task<GenericResponse<LoginUserResponseDto>> LoginUserAsync(LoginUserRequestDto requestDto);
}