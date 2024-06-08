using AuthDemo.Domain.Entities;

namespace AuthDemo.Application.Abstractions.Identity;
public interface IIdentityService
{
    Task<bool> CreateUserAsync(UserEntity user, string password);
    Task<bool> AddUserRoleAsync(UserEntity user, string role);
    Task DeleteUserAsync(UserEntity user);
    Task<IList<string>> GetUserRolesAsync(UserEntity user);
    Task<UserEntity?> FindByUserNameAsync(string userName);
    Task<bool> ValidateUserPasswordAsync(UserEntity user, string currentPassword);
    Task<bool> ChangeUserPasswordAsync(UserEntity user, string newPassword);
    Task UpdateUserAsync(UserEntity user);
    Task<UserEntity?> FindByEmailAsync(string email);
}
