namespace AuthDemo.Domain.Dtos.Auth;

public sealed record RegisterUserRequestDto(string FirstName,
    string LastName,
    string Email,
    string Password);
