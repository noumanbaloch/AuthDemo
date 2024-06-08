using AuthDemo.Application.Abstractions.Persistence;
using AuthDemo.Persistence.Contexts;
using AuthDemo.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthDemo.Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AuthDemoDbContext>((provider, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        },
        ServiceLifetime.Scoped,
        ServiceLifetime.Singleton);

        services.AddScoped<IAuthRepository, AuthRepository>();

        return services;
    }
}
