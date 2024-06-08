using AuthDemo.Application.Abstractions.Persistence;
using AuthDemo.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AuthDemo.Persistence.Repositories;
internal class AuthRepository(AuthDemoDbContext context) : BaseRepository(context), IAuthRepository
{
    public async Task<bool> UserAlreadyExistsAsync(string email)
        => await _context.AppUsers
        .AnyAsync(x => x.Email!.ToLower() == email.ToLower());
}
