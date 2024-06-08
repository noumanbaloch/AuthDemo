namespace AuthDemo.Domain.Dtos.Auth;
public sealed record LoginUserRequestDto(string Email,
    string Password);