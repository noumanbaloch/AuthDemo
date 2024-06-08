using AuthDemo.Application.Abstractions.Application;
using AuthDemo.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AuthDemo.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserResolverService, UserResolverService>();
        return services;
    }
}