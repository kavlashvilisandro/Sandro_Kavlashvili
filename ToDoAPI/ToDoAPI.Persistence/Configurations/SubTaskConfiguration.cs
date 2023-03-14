using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoAPI.Persistence.Models;

namespace ToDoAPI.Persistence.Configurations
{
    public class SubTaskConfiguration : IEntityTypeConfiguration<SubTask>
    {
        public void Configure(EntityTypeBuilder<SubTask> builder)
        {
            builder.HasKey((SubTask x) => x.ID);

            builder.Property((SubTask x) => x.ID)
                .HasColumnName("SubTaskID");


            builder.Property((SubTask x) => x.Title)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsUnicode(false).IsRequired();

            builder
                .HasOne((SubTask x) => x.SubTaskOwnerToDo)
                .WithMany((ToDo x) => x.SubTasks)
                .HasForeignKey((SubTask x) => x.ToDoItemID)
                .HasPrincipalKey((ToDo d) => d.ID);
        }
    }
}
