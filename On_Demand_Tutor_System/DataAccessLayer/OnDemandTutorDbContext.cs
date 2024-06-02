using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

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

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Tutor> Tutors { get; set; }

    public virtual DbSet<TutorService> TutorServices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnectionString());
    }

    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DBDefault"];
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.AchievementId).HasName("PK__Achievem__276330E0BB396C1F");

            entity.ToTable("Achievement");

            entity.Property(e => e.AchievementId).HasColumnName("AchievementID");
            entity.Property(e => e.Achievement1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Achievement");
            entity.Property(e => e.Certificate)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TutorId).HasColumnName("TutorID");

            entity.HasOne(d => d.Tutor).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.TutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Achieveme__Tutor__3F466844");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Booking__3214EC2740FD6D66");

            entity.ToTable("Booking");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.TutorId).HasColumnName("TutorID");

            entity.HasOne(d => d.Service).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__Service__4BAC3F29");

            entity.HasOne(d => d.Status).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__StatusI__4CA06362");

            entity.HasOne(d => d.Student).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__Student__49C3F6B7");

            entity.HasOne(d => d.Tutor).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__TutorID__4AB81AF0");
        });

        modelBuilder.Entity<BookingSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookingS__3214EC27E39A8450");

            entity.ToTable("BookingSchedule");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.ScId).HasColumnName("ScID");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingSchedules)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingSc__Booki__5165187F");

            entity.HasOne(d => d.Sc).WithMany(p => p.BookingSchedules)
                .HasForeignKey(d => d.ScId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingSch__ScID__52593CB8");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FbId).HasName("PK__Feedback__36769D6CC7909788");

            entity.Property(e => e.FbId).HasColumnName("FbID");
            entity.Property(e => e.Detail).HasColumnType("text");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.TutorId).HasColumnName("TutorID");

            entity.HasOne(d => d.Student).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedbacks__Stude__4316F928");

            entity.HasOne(d => d.Tutor).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.TutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedbacks__Tutor__4222D4EF");
        });

        modelBuilder.Entity<Moderator>(entity =>
        {
            entity.HasKey(e => e.ModId).HasName("PK__Moderato__FB1F17878061028C");

            entity.ToTable("Moderator");

            entity.Property(e => e.ModId).HasColumnName("ModID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TutorId).HasColumnName("TutorID");

            entity.HasOne(d => d.Tutor).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.TutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Moderator__Tutor__5535A963");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Schedule__3214EC2727B3EE08");

            entity.ToTable("Schedule");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasMaxLength(25);
            entity.Property(e => e.Slot)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Service__3214EC2739A727BC");

            entity.ToTable("Service");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Service1)
                .HasMaxLength(255)
                .HasColumnName("Service");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__C8EE204329F99D5A");

            entity.ToTable("Status");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.Status1)
                .HasMaxLength(50)
                .HasColumnName("Status");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A799678314D");

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
            entity.HasKey(e => e.TutorId).HasName("PK__Tutor__77C70FC2EFC124A6");

            entity.ToTable("Tutor");

            entity.Property(e => e.TutorId).HasColumnName("TutorID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Fullname).HasMaxLength(255);
            entity.Property(e => e.Major).HasMaxLength(255);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<TutorService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TutorSer__3214EC277562C2B0");

            entity.ToTable("TutorService");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.TutorId).HasColumnName("TutorID");

            entity.HasOne(d => d.Service).WithMany(p => p.TutorServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TutorServ__Servi__45F365D3");

            entity.HasOne(d => d.Tutor).WithMany(p => p.TutorServices)
                .HasForeignKey(d => d.TutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TutorServ__Tutor__46E78A0C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
