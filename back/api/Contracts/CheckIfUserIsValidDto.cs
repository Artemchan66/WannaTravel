namespace WannaTravel.API.Contracts;

public record CheckIfUserIsValidDto
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
