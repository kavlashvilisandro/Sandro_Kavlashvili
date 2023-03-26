using Microsoft.EntityFrameworkCore;
using EventsItAcademyGe.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsItAcademyGe.Persistence.Configurations
{
    public class EventStatussesConfigurations : IEntityTypeConfiguration<EventStatus>
    {
        public void Configure(EntityTypeBuilder<EventStatus> builder)
        {
            builder.HasKey((EventStatus status) => status.ID);

            builder.Property((EventStatus status) => status.EventStatusDescription)
                .HasMaxLength(200).IsUnicode(false).HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(status => status.EventStatusCode).IsRequired();

            builder
                .HasMany((EventStatus status) => status.ReleatedEvents)
                .WithOne()
                .HasForeignKey((Event Event) => Event.EventStatus)
                .HasPrincipalKey((EventStatus status) => status.EventStatusCode)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
