using EventManagementWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagementWebApp.Data.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.firstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.lastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.DateJoined)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
