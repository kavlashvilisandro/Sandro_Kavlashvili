using Microsoft.EntityFrameworkCore;
using EventsItAcademyGe.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsItAcademyGe.Persistence.Configurations
{
    public class EventsConfigurations : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey((Event e) => e.ID);

            builder.Property(e => e.EventName).IsRequired()
                .HasMaxLength(30).HasColumnType("varchar(30)")
                .IsUnicode(false);

            builder.Property(e => e.EventDescription).IsRequired()
                .HasMaxLength(300).HasColumnType("varchar(300)")
                .IsUnicode(false);

            builder.Property(e => e.TicketAmount).IsRequired();

            builder.Property(e => e.StartDate).IsRequired()
                .HasColumnType("date");

            builder.Property(e => e.EndData).IsRequired()
                .HasColumnType("date");

            builder
                .HasOne<User>()
                .WithMany((User user) => user.ReleatedEvents)
                .HasForeignKey((Event e) => e.OwnerID)
                .HasPrincipalKey((User user) => user.ID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
