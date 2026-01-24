using WannaTravel.Domain.Enums;

namespace WannaTravel.Logic.DTOs;

public class UpdateCountryDto
{
    public string Country { get; set; } = string.Empty;
    public UserCountryStatus? Status { get; set; }
}