﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Schedlify.Data;

#nullable disable

namespace Schedlify.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Schedlify.Models.Assignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Building")
                        .HasColumnType("text");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uuid");

                    b.Property<string>("ClassType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Date_")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("interval");

                    b.Property<string>("Lecturer")
                        .HasColumnType("text");

                    b.Property<string>("Mode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RoomNumber")
                        .HasColumnType("text");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("interval");

                    b.Property<string>("Type_")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Weekday")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("Schedlify.Models.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Schedlify.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Schedlify.Models.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AdministratorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UniversityId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UniversityId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Schedlify.Models.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("AutoUpdate")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ForkScheduleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ForkScheduleId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Schedlify.Models.ScheduleAssignment", b =>
                {
                    b.Property<Guid>("AssignmentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uuid");

                    b.HasKey("AssignmentId", "ScheduleId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("ScheduleAssignments");
                });

            modelBuilder.Entity("Schedlify.Models.TemplateSlot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ClassNumber")
                        .HasColumnType("integer");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("interval");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("TemplateSlots");
                });

            modelBuilder.Entity("Schedlify.Models.University", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("Schedlify.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("TgId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Schedlify.Models.UserSchedule", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ScheduleId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Notify")
                        .HasColumnType("boolean");

                    b.HasKey("UserId", "ScheduleId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("UserSchedules");
                });

            modelBuilder.Entity("Schedlify.Models.Assignment", b =>
                {
                    b.HasOne("Schedlify.Models.Class", "Class")
                        .WithMany("Assignments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("Schedlify.Models.Class", b =>
                {
                    b.HasOne("Schedlify.Models.Group", "Group")
                        .WithMany("Classes")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedlify.Models.User", "User")
                        .WithMany("Classes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Schedlify.Models.Department", b =>
                {
                    b.HasOne("Schedlify.Models.University", "University")
                        .WithMany("Departments")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("Schedlify.Models.Group", b =>
                {
                    b.HasOne("Schedlify.Models.User", "Administrator")
                        .WithMany("AdminGroups")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedlify.Models.Department", "Department")
                        .WithMany("Groups")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedlify.Models.University", "University")
                        .WithMany("Groups")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");

                    b.Navigation("Department");

                    b.Navigation("University");
                });

            modelBuilder.Entity("Schedlify.Models.Schedule", b =>
                {
                    b.HasOne("Schedlify.Models.Schedule", "ForkSchedule")
                        .WithMany()
                        .HasForeignKey("ForkScheduleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Schedlify.Models.Group", "Group")
                        .WithMany("Schedules")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedlify.Models.User", "User")
                        .WithMany("Schedules")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ForkSchedule");

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Schedlify.Models.ScheduleAssignment", b =>
                {
                    b.HasOne("Schedlify.Models.Assignment", "Assignment")
                        .WithMany("ScheduleAssignments")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedlify.Models.Schedule", "Schedule")
                        .WithMany("ScheduleAssignments")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Schedlify.Models.TemplateSlot", b =>
                {
                    b.HasOne("Schedlify.Models.Department", "Department")
                        .WithMany("TemplateSlots")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedlify.Models.User", "User")
                        .WithMany("TemplateSlots")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Schedlify.Models.UserSchedule", b =>
                {
                    b.HasOne("Schedlify.Models.Schedule", "Schedule")
                        .WithMany("UserSchedules")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedlify.Models.User", "User")
                        .WithMany("UserSchedules")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Schedlify.Models.Assignment", b =>
                {
                    b.Navigation("ScheduleAssignments");
                });

            modelBuilder.Entity("Schedlify.Models.Class", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("Schedlify.Models.Department", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("TemplateSlots");
                });

            modelBuilder.Entity("Schedlify.Models.Group", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Schedlify.Models.Schedule", b =>
                {
                    b.Navigation("ScheduleAssignments");

                    b.Navigation("UserSchedules");
                });

            modelBuilder.Entity("Schedlify.Models.University", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Groups");
                });

            modelBuilder.Entity("Schedlify.Models.User", b =>
                {
                    b.Navigation("AdminGroups");

                    b.Navigation("Classes");

                    b.Navigation("Schedules");

                    b.Navigation("TemplateSlots");

                    b.Navigation("UserSchedules");
                });
#pragma warning restore 612, 618
        }
    }
}
