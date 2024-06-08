using AuthDemo.Application.Abstractions.Application;
using AuthDemo.Application.Abstractions.Identity;
using AuthDemo.Application.Abstractions.Persistence;
using AuthDemo.Application.Mapping;
using AuthDemo.Domain.Constants;
using AuthDemo.Domain.Dtos.Auth;
using AuthDemo.Domain.GenericResponse;
using System.Transactions;

namespace AuthDemo.Application.Services;
public class AuthService : IAuthService
{
    private readonly IIdentityService _identityService;
    private readonly IAuthRepository _authRepository;
    private readonly ITokenService _tokenService;

    public AuthService(IIdentityService identityService,
        IAuthRepository authRepository,
        ITokenService tokenService)
    {
        _identityService = identityService;
        _authRepository = authRepository;
        _tokenService = tokenService;
    }


    public async Task<GenericResponse<RegisterUserResponseDto>> RegisterUserAsync(RegisterUserRequestDto requestDto)
    {
        using (var scope = new TransactionScope(TransactionScopeOption.Required,
            new TransactionOptions() { IsolationLevel = IsolationLevel.Serializable },
            TransactionScopeAsyncFlowOption.Enabled))
        {
            if (await _identityService.FindByEmailAsync(requestDto.Email) is not null)
                return GenericResponse<RegisterUserResponseDto>.Failure(ApiResponseMessages.USER_ALREADY_EXIST, ApiStatusCodes.USER_ALREADY_EXIST);

            await _identityService.CreateUserAsync(requestDto.Map(), requestDto.Password);

            var user = await _identityService.FindByEmailAsync(requestDto.Email);

            if (!await _identityService.AddUserRoleAsync(user!, UserRoles.ADMIN_ROLE))
            {
                await _identityService.DeleteUserAsync(user!);

                scope.Complete();

                return GenericResponse<RegisterUserResponseDto>.Failure(ApiResponseMessages.UNABLE_TO_COMPLETE_PROCESS, ApiStatusCodes.UNABLE_TO_COMPLETE_PROCESS);
            }

            var roles = await _identityService.GetUserRolesAsync(user!);

            var token = _tokenService.GenerateToken(user!.Id, user.Email!, user.FirstName, user.LastName, roles);

            scope.Complete();

            return GenericResponse<RegisterUserResponseDto>.Success(new RegisterUserResponseDto(user.Email!,
                user.FirstName,
                user.LastName,
                token), $"{ApiResponseMessages.WELCOME_MESSAGE}{user.FirstName}", ApiStatusCodes.WELCOME_MESSAGE);
        }
    }

    public async Task<GenericResponse<LoginUserResponseDto>> LoginUserAsync(LoginUserRequestDto requestDto)
    {
        var user = await _identityService.FindByEmailAsync(requestDto.Email);
        if (user is null || !await _authRepository.UserAlreadyExistsAsync(requestDto.Email))
        {
            return GenericResponse<LoginUserResponseDto>.Failure(ApiResponseMessages.INVALID_USERNAME_OR_PASSWORD, ApiStatusCodes.INVALID_USERNAME_OR_PASSWORD);
        }

        if (!await _identityService.ValidateUserPasswordAsync(user, requestDto.Password))
        {
            return GenericResponse<LoginUserResponseDto>.Failure(ApiResponseMessages.INVALID_USERNAME_OR_PASSWORD, ApiStatusCodes.INVALID_USERNAME_OR_PASSWORD);
        }

        var roles = await _identityService.GetUserRolesAsync(user);

        var token = _tokenService.GenerateToken(user!.Id, user.Email!, user.FirstName, user.LastName, user.Region, roles);

        return GenericResponse<LoginUserResponseDto>.Success(user.Map(token), $"{ApiResponseMessages.WELCOME_BACK_MESSAGE}{user.FirstName}", ApiStatusCodes.WELCOME_MESSAGE);
    }
}
