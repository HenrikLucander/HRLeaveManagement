using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "75e0f3bf-d607-4b1b-bce9-533ca6f7e60e",
                    UserId = "e2562377-51c5-4424-b59c-5c05a12f16fe"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "19e73960-6e7d-4f16-baf4-c51ce56bd0e1",
                    UserId = "8d87c031-d1e6-442d-9901-6c0e7497660b"
                }
            );
        }
    }
}
