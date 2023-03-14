using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoAPI.Persistence.Models;

namespace ToDoAPI.Persistence.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {

            builder.Property(s => s.StatusDefinition)
                .IsRequired().HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnType("varchar(50)");

        }
    }
}
