using EventManagementWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagementWebApp.Data.Configurations
{
    public class ReviewConfigurations : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Event)
                   .WithMany(e => e.Reviews) 
                   .HasForeignKey(x => x.EventId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Member)
                   .WithMany(m => m.Reviews)
                   .HasForeignKey(x => x.MemberId)
                   .OnDelete(DeleteBehavior.Restrict); 

            builder.Property(x => x.Comment)
                   .HasMaxLength(500) 
                   .IsRequired(false);

            builder.Property(x => x.Rating)
                   .IsRequired(); 
        }
    }

}
