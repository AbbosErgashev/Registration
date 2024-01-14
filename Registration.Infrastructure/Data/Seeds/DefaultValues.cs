using Microsoft.EntityFrameworkCore;
using Registration.Infrastructure.Entities;

namespace Registration.Infrastructure.Data.Seeds;

public static partial class DefaultValues
{
    public static void SuperUser(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FirstName = "Abbos",
                LastName = "Ergashev",
                Address = "Tashkent",
                Email = "eaxusniddinovich@gmail.com",
                PhoneNumber = "+998939887773",
                AboutMe = "I'm a Student and Software Engineer",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            });
    }
}
