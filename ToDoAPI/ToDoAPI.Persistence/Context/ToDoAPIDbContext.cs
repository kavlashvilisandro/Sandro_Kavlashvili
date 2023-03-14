using System;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Persistence.Models;

namespace ToDoAPI.Persistence.Context
{
    public class ToDoAPIDbContext : DbContext
    {
        #region ctor
        public ToDoAPIDbContext(DbContextOptions<ToDoAPIDbContext> options) : base(options)
        {

        }
        #endregion


        #region DbSets

        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<ToDo> ToDoTable { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Status> Statuses { get; set; }

        #endregion


        #region Configurations
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ToDoAPIDbContext).Assembly);

            List<Status> PreDefinedStatuses = new List<Status>()
            {
                new Status()
                {
                    ID = 1,
                    StatusDefinition = "Active"
                },

                new Status()
                {
                    ID = 2,
                    StatusDefinition = "Done"
                },

                new Status()
                {
                    ID = 3,
                    StatusDefinition = "Deleted"
                }
            };

            //Seeding
            builder.Entity<Status>().HasData(PreDefinedStatuses);
        }

        #endregion


    }
}
