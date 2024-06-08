namespace AuthDemo.Application.Abstractions.Persistence;
public interface IAuthRepository
{
    Task<bool> UserAlreadyExistsAsync(string email);
}
