using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoAPI.Persistence.Models;

namespace ToDoAPI.Persistence.Configurations
{
    public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasKey(todo => todo.ID);

            builder.Property(todo => todo.ID)
                .HasColumnName("ToDoID");

            builder.Property(todo => todo.Title)
                .HasMaxLength(100).IsUnicode(false)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .HasOne<Status>()
                .WithMany()
                .HasForeignKey(todo => todo.Status)
                .HasPrincipalKey((Status s) => s.ID);

            builder
                .HasOne((ToDo x) => x.Owner)
                .WithMany((User owner) => owner.ToDoTasks)
                .HasForeignKey((ToDo x) => x.OwnerID)
                .HasPrincipalKey((User owner) => owner.ID);
        }
    }
}
