using EventsItAcademyGe.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsItAcademyGe.Persistence.Configurations
{
    public class AdminConfigurations : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey((Admin admin) => admin.AdminID);

            builder.Property((Admin admin) => admin.AdminName)
                .HasMaxLength(50).IsUnicode(false).HasColumnType("varchar(50)")
                .IsRequired();
        }
    }
}
