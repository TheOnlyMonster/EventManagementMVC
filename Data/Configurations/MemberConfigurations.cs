using EventManagementWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagementWebApp.Data.Configurations
{
    public class MemberConfigurations : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasMany(m => m.Registrations)
                .WithOne(r => r.Member)
                .HasForeignKey(r => r.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.Reviews)
                .WithOne(r => r.Member)
                .HasForeignKey(r => r.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
