using AuthDemo.Application.Abstractions.Identity;
using AuthDemo.Domain.Configurations;
using AuthDemo.Domain.Constants;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthDemo.Identity.Services;
public class TokenService : ITokenService
{
    private readonly SymmetricSecurityKey _key;
    private readonly AuthenticationConfiguration _authenticationConfiguration;

    public TokenService(IOptions<AuthenticationConfiguration> authenticationConfiguration)
    {
        _authenticationConfiguration = authenticationConfiguration.Value;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationConfiguration.SecretKey));
    }

    public string GenerateToken(int userId, string email, string firstName, string lastName, string region, IEnumerable<string> roles)
    {
        var claims = new List<Claim>()
            {
                new (JwtClaimNames.USER_ID, userId.ToString()),
                new (JwtClaimNames.FIRST_NAME, firstName ?? string.Empty),
                new (JwtClaimNames.LAST_NAME, lastName ?? string.Empty),
                new (JwtClaimNames.REGION, region ?? string.Empty),
                new (JwtClaimNames.FULL_NAME, $"{firstName} {lastName}"),
                new (JwtClaimNames.EMAIL, email),
                new (JwtClaimNames.JTI, Guid.NewGuid().ToString()),
                new (JwtClaimNames.IAT, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),
            };

        foreach (var role in roles)
        {
            claims.Add(new Claim(type: ClaimTypes.Role, role));
        }

        var creds = new SigningCredentials(_key, algorithm: SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
                   issuer: _authenticationConfiguration.Issuer,
                   audience: _authenticationConfiguration.Audience,
                   claims: claims,
                   expires: DateTime.Now.AddDays(MagicNumbers.TOKEN_EXPIRY_DAYS),
                   signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}