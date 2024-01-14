using Registration.Infrastructure.Entities.Base;

namespace Registration.Infrastructure.Entities;

public class User : EntityBase
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Address { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public string? AboutMe { get; set; }
}
