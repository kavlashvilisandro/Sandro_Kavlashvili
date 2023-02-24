using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoAPI.Persistence.Models;




namespace ToDoAPI.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey((User U) => U.ID);

            builder.Property(u => u.ID)
                .HasColumnName("UserID");

            builder.Property((User U) => U.UserName)
                .HasMaxLength(50).IsUnicode(false)
                .HasColumnType("varchar(50)")
                .IsRequired();


            builder.Property((User U) => U.PasswordHash)
                .IsUnicode(false).HasColumnType("varchar(8000)")
                .IsRequired();


            
        }
    }
}
