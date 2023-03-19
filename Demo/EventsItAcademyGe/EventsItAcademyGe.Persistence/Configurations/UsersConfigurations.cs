using Microsoft.EntityFrameworkCore;
using EventsItAcademyGe.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsItAcademyGe.Persistence.Configurations
{
    public class UsersConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey((User user) => user.ID);

            builder.Property(e => e.UserName)
                .HasMaxLength(20).IsUnicode(false)
                .HasColumnType("varchar(20)").IsRequired();

            builder.Property(u => u.CreationDate)
                .IsRequired();

            builder.Property(u => u.ModifiedDate)
                .IsRequired();

            builder.Property((User user) => user.Password)
                .HasColumnType("varchar(1000)").HasMaxLength(1000)
                .IsUnicode(false).IsRequired();

            
        }
    }
}
