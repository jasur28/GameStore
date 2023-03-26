using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace GameStore.DAL.Helpers
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });
        }
    }
}
