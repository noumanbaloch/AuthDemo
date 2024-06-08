namespace AuthDemo.Domain.Dtos.Auth;

public sealed record RegisterUserResponseDto(string Email,
    string FirstName,
    string LastName,
    string Token);