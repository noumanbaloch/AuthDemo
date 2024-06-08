using AuthDemo.Application.Abstractions.Application;
using AuthDemo.Domain.Constants;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AuthDemo.Application.Services;

public class UserResolverService : IUserResolverService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserResolverService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetUserId()
        => Convert.ToInt32(GetClaimValue(JwtClaimNames.USER_ID));

    public string GetUserEmail()
        => GetClaimValue(JwtClaimNames.EMAIL);

    public bool IsUserAuthenticated()
        => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == true;

    #region Private Methods
    private string GetClaimValue(string claimType)
    {
        if (!IsUserAuthenticated())
        {
            throw new UnauthorizedAccessException(ExceptionMessages.UNAUTHORIZED_USER);
        }

        return _httpContextAccessor.HttpContext!.User.FindFirstValue(claimType)!;
    }
    #endregion
}