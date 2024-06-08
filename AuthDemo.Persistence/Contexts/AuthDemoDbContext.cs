using AuthDemo.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthDemo.Persistence.Contexts;
public class AuthDemoDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
{
    public AuthDemoDbContext(DbContextOptions<AuthDemoDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseSqlServer()
        .UseSnakeCaseNamingConvention();

    public DbSet<UserEntity> AppUsers => Set<UserEntity>();
}