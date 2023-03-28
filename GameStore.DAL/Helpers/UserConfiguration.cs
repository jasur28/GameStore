using GameStore.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.DAL.Helpers
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "Admin",
                Email = "admin@gamestore.com",
                NormalizedEmail = "ADMIN@GAMESTORE.COM",
                NormalizedUserName = "ADMIN"
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin@295");

            builder.HasData(user);
        }
    }
}
