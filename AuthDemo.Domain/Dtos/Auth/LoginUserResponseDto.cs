namespace AuthDemo.Domain.Dtos.Auth;

public sealed record LoginUserResponseDto(string Email,
    string FirstName,
    string LastName,
    string Region,
    string Token);