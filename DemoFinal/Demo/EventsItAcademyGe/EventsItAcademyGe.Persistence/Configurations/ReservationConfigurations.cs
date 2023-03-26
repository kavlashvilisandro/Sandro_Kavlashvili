using Microsoft.EntityFrameworkCore;
using EventsItAcademyGe.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsItAcademyGe.Persistence.Configurations
{
    public class ReservationConfigurations : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey((Reservation res) => res.ID);

            builder
                .HasOne((Reservation res) => res.User)
                .WithMany()
                .HasForeignKey((Reservation res) => res.UserID)
                .HasPrincipalKey((User user) => user.ID)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne((Reservation res) => res.Event)
                .WithMany()
                .HasForeignKey((Reservation res) => res.EventID)
                .HasPrincipalKey((Event Event) => Event.ID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
