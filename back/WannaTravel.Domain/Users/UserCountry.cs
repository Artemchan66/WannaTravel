using WannaTravel.Domain.Enums;

namespace WannaTravel.Infrastructure.Entities;

public class UserCountry
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public string CountryName { get; set; } = string.Empty;

    public UserCountryStatus Status { get; set; }
}
