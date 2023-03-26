﻿// <auto-generated />
using System;
using EventsItAcademyGe.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventsItAcademyGe.Persistence.Migrations
{
    [DbContext(typeof(EventsItAcademyGeDbContext))]
    partial class EventsItAcademyGeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventsItAcademyGe.Domain.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"));

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            AdminID = 1,
                            AdminName = "MainAdmin",
                            AdminPassword = "fdb203aa7d6e599674fed8d2a2bfa1024bb37907db5314e8adaa1b33bdaa521c67c3476af46856243ef1dea5326bf78818a98086261ddfc0c5c2c5541f166c55"
                        });
                });

            modelBuilder.Entity("EventsItAcademyGe.Domain.Models.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndData")
                        .HasColumnType("date");

                    b.Property<string>("EventDescription")
                        .IsRequired()
                        .HasMaxLength(300)
                        .IsUnicode(false)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("EventStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OwnerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TicketAmount")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EventStatus");

                    b.HasIndex("OwnerID");

                    b.HasIndex("Status");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventsItAcademyGe.Domain.Models.EventStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("EventStatusCode")
                        .HasColumnType("int");

                    b.Property<string>("EventStatusDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("ID");

                    b.ToTable("EventStatusses");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            EventStatusCode = 1,
                            EventStatusDescription = "Pending"
                        },
                        new
                        {
                            ID = 2,
                            EventStatusCode = 2,
                            EventStatusDescription = "Active"
                        },
                        new
                        {
                            ID = 3,
                            EventStatusCode = 3,
                            EventStatusDescription = "Finished"
                        });
                });

            modelBuilder.Entity("EventsItAcademyGe.Domain.Models.Reservation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EventID");

                    b.HasIndex("UserID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("EventsItAcademyGe.Domain.Models.Status", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("StatusCode")
                        .HasColumnType("int");

                    b.Property<string>("StatusMessage")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("ID");

                    b.ToTable("Statusses");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            StatusCode = 1,
                            StatusMessage = "Active"
                        },
                        new
                        {
                            ID = 2,
                            StatusCode = 2,
                            StatusMessage = "Deleted"
                        });
                });

            modelBuilder.Entity("EventsItAcademyGe.Domain.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsModerator")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("ID");

                    b.HasIndex("Status");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EventsItAcademyGe.Domain.Models.Event", b =>
                {
                    b.HasOne("EventsItAcademyGe.Domain.Models.EventStatus", null)
                        .WithMany("ReleatedEvents")
                        .HasForeignKey("EventStatus")
                        .HasPrincipalKey("EventStatusCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EventsItAcademyGe.Domain.Models.User", null)
                        .WithMany("ReleatedEvents")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EventsItAcademyGe.Domain.Models.Status", null)
                        .WithMany("EventsWithThisStatusCode")
                        .HasForeignKey("Status")
                        .HasPrincipalKey("StatusCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("EventsItAcademyGe.Domain.Models.Reservation", b =>
                {
                    b.HasOne("EventsItAcademyGe.Domain.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EventsItAcademyGe.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventsItAcademyGe.Domain.Models.User", b =>
                {
                    b.HasOne("EventsItAcademyGe.Domain.Models.Status", null)
                        .WithMany("UsersWithThisStatusCode")
                        .HasForeignKey("Status")
                        .HasPrincipalKey("StatusCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("EventsItAcademyGe.Domain.Models.EventStatus", b =>
                {
                    b.Navigation("ReleatedEvents");
                });

            modelBuilder.Entity("EventsItAcademyGe.Domain.Models.Status", b =>
                {
                    b.Navigation("EventsWithThisStatusCode");

                    b.Navigation("UsersWithThisStatusCode");
                });

            modelBuilder.Entity("EventsItAcademyGe.Domain.Models.User", b =>
                {
                    b.Navigation("ReleatedEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
