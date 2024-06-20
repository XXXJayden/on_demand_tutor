using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects.Models;

public partial class OnDemandTutorDbContext : DbContext
{
    public OnDemandTutorDbContext()
    {
    }

    public OnDemandTutorDbContext(DbContextOptions<OnDemandTutorDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingSchedule> BookingSchedules { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Moderator> Moderators { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Tutor> Tutors { get; set; }

    public virtual DbSet<TutorService> TutorServices { get; set; }

    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DBDefault"];
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnectionString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.AchievementId).HasName("PK__Achievem__276330E0648B4242");

            entity.ToTable("Achievement");

            entity.Property(e => e.AchievementId).HasColumnName("AchievementID");
            entity.Property(e => e.Certificate)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TutorId).HasColumnName("TutorID");

            entity.HasOne(d => d.Tutor).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.TutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Achieveme__Tutor__3C69FB99");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Booking__3214EC2711B940E5");

            entity.ToTable("Booking");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PaymentMethods)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Status)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.TutorId).HasColumnName("TutorID");

            entity.HasOne(d => d.Service).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__Service__44FF419A");

            entity.HasOne(d => d.Student).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__Student__4316F928");

            entity.HasOne(d => d.Tutor).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__TutorID__440B1D61");
        });

        modelBuilder.Entity<BookingSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookingS__3214EC27E06D84E6");

            entity.ToTable("BookingSchedule");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.ScId).HasColumnName("ScID");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingSchedules)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingSc__Booki__4CA06362");

            entity.HasOne(d => d.Sc).WithMany(p => p.BookingSchedules)
                .HasForeignKey(d => d.ScId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingSch__ScID__4D94879B");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FbId).HasName("PK__Feedback__36769D6CB579EFC0");

            entity.Property(e => e.FbId).HasColumnName("FbID");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.Detail).HasColumnType("text");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Booking).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedbacks__Booki__47DBAE45");
        });

        modelBuilder.Entity<Moderator>(entity =>
        {
            entity.HasKey(e => e.ModId).HasName("PK__Moderato__FB1F1787253BD1A0");

            entity.ToTable("Moderator");

            entity.Property(e => e.ModId).HasColumnName("ModID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Fullname).HasMaxLength(255);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Schedule__3214EC27B0C53E75");

            entity.ToTable("Schedule");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasMaxLength(25);
            entity.Property(e => e.Slot)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Service__3214EC278987E19A");

            entity.ToTable("Service");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Service1)
                .HasMaxLength(255)
                .HasColumnName("Service");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A79BE9A2DCF");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Fullname).HasMaxLength(255);
            entity.Property(e => e.Grade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<Tutor>(entity =>
        {
            entity.HasKey(e => e.TutorId).HasName("PK__Tutor__77C70FC2BB19FDB2");

            entity.ToTable("Tutor");

            entity.Property(e => e.TutorId).HasColumnName("TutorID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Fullname).HasMaxLength(255);
            entity.Property(e => e.Grade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Major).HasMaxLength(255);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<TutorService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TutorSer__3214EC27CF45DE98");

            entity.ToTable("TutorService");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.TutorId).HasColumnName("TutorID");

            entity.HasOne(d => d.Service).WithMany(p => p.TutorServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TutorServ__Servi__3F466844");

            entity.HasOne(d => d.Tutor).WithMany(p => p.TutorServices)
                .HasForeignKey(d => d.TutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TutorServ__Tutor__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
