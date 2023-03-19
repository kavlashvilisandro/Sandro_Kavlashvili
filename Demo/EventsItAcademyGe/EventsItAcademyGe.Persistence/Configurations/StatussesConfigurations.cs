using Microsoft.EntityFrameworkCore;
using EventsItAcademyGe.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsItAcademyGe.Persistence.Configurations
{
    public class StatussesConfigurations : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey((Status status) => status.ID);

            builder.Property((Status status) => status.StatusMessage)
                .HasMaxLength(200).IsUnicode(false).HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(status => status.StatusCode).IsRequired();

            builder
                .HasMany((Status status) => status.UsersWithThisStatusCode)
                .WithOne()
                .HasForeignKey((User user) => user.Status)
                .HasPrincipalKey((Status status) => status.StatusCode)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany((Status status) => status.EventsWithThisStatusCode)
                .WithOne()
                .HasForeignKey((Event Event) => Event.Status)
                .HasPrincipalKey((Status status) => status.StatusCode)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
