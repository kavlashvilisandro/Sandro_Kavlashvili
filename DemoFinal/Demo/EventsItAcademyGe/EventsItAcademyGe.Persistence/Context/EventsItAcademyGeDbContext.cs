﻿using Microsoft.EntityFrameworkCore;
using EventsItAcademyGe.Domain.Models;

namespace EventsItAcademyGe.Persistence.Context
{
    public class EventsItAcademyGeDbContext : DbContext
    {
        #region ctor
        public EventsItAcademyGeDbContext(DbContextOptions<EventsItAcademyGeDbContext> options) : base(options)
        {

        }
        #endregion

        #region Tables

        public DbSet<User> Users { get; set; }
        public DbSet<Status> Statusses { get; set; }
        public DbSet<EventStatus> EventStatusses { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Admin> Admins { get; set; }

        #endregion

        #region TableConfigurations

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(EventsItAcademyGeDbContext).Assembly);

            //Seeding
            builder.Entity<Status>().HasData(new List<Status>()
            {
                new Status(){ID = 1,StatusCode = 1, StatusMessage = "Active"},
                new Status(){ID = 2,StatusCode = 2, StatusMessage = "Deleted"}
            });

            builder.Entity<EventStatus>().HasData(new List<EventStatus>()
            {
                new EventStatus(){ID = 1,EventStatusCode = 1,EventStatusDescription = "Pending"},
                new EventStatus(){ID = 2,EventStatusCode = 2,EventStatusDescription = "Active"},
                new EventStatus(){ID = 3,EventStatusCode = 3,EventStatusDescription = "Finished"}
            });

            builder.Entity<Admin>().HasData(new List<Admin>()
            {
                new Admin(){AdminID = 1, AdminName = "MainAdmin",
                AdminPassword = "fdb203aa7d6e599674fed8d2a2bfa1024bb37907db5314e8adaa1b33bdaa521c67c3476af46856243ef1dea5326bf78818a98086261ddfc0c5c2c5541f166c55"}
            });
        }

        #endregion
    }
}
