using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SoftEng.DataAccess.DataObjects
{
    public partial class team7Context : DbContext
    {
        public team7Context()
        {
        }

        public team7Context(DbContextOptions<team7Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassDay> ClassDays { get; set; }
        public virtual DbSet<CompareRequest> CompareRequests { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Recurrence> Recurrences { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;user=team7;password=sql882570;database=team7");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class", "team7");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<ClassDay>(entity =>
            {
                entity.ToTable("ClassDay", "team7");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClassId).HasColumnType("int(11)");

                entity.Property(e => e.DayOfWeek).HasColumnType("int(11)");
            });

            modelBuilder.Entity<CompareRequest>(entity =>
            {
                entity.ToTable("CompareRequest", "team7");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Accepted).HasColumnType("tinyint(1)");

                entity.Property(e => e.FromUser).HasColumnType("int(11)");

                entity.Property(e => e.ToUser).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Day>(entity =>
            {
                entity.ToTable("Day", "team7");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Day1)
                    .IsRequired()
                    .HasColumnName("Day")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event", "team7");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClassId).HasColumnType("int(11)");

                entity.Property(e => e.EventDate).HasColumnType("date");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RecurrenceId).HasColumnType("int(11)");

                entity.Property(e => e.TaskId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Recurrence>(entity =>
            {
                entity.ToTable("Recurrence", "team7");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task", "team7");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IsComplete).HasColumnType("tinyint(1)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "team7");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IsAdmin).HasColumnType("int(1)");

                entity.Property(e => e.Phash)
                    .IsRequired()
                    .HasColumnName("PHash")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}
