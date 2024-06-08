namespace AuthDemo.Application.Abstractions.Identity;
public interface ITokenService
{
    string GenerateToken(int userId, string email, string firstName, string lastName, string region, IEnumerable<string> roles);
}
