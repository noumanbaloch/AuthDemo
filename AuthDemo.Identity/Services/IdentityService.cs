using AuthDemo.Application.Abstractions.Identity;
using AuthDemo.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AuthDemo.Identity.Services;
internal class IdentityService : IIdentityService
{
    private readonly UserManager<UserEntity> _userManager;

    public IdentityService(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> CreateUserAsync(UserEntity user, string password)
        => (await _userManager.CreateAsync(user, password)).Succeeded;

    public async Task<bool> AddUserRoleAsync(UserEntity user, string role)
        => (await _userManager.AddToRoleAsync(user, role)).Succeeded;

    public async Task DeleteUserAsync(UserEntity user)
        => await _userManager.DeleteAsync(user);

    public async Task<IList<string>> GetUserRolesAsync(UserEntity user)
        => await _userManager.GetRolesAsync(user);

    public async Task<UserEntity?> FindByUserNameAsync(string userName)
        => await _userManager.FindByNameAsync(userName);

    public async Task<bool> ValidateUserPasswordAsync(UserEntity user, string currentPassword)
        => await _userManager.CheckPasswordAsync(user, currentPassword);

    public async Task<bool> ChangeUserPasswordAsync(UserEntity user, string newPassword)
    {
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
        return result.Succeeded;
    }

    public async Task UpdateUserAsync(UserEntity user)
        => await _userManager.UpdateAsync(user);

    public async Task<UserEntity?> FindByEmailAsync(string email)
        => await _userManager.FindByEmailAsync(email);
}
