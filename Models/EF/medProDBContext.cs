using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MedPro.Models.EF
{
    public partial class medProDBContext : DbContext
    {
        public medProDBContext()
        {
        }

        public medProDBContext(DbContextOptions<medProDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Availability> Availabilities { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Doctorservice> Doctorservices { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Time> Times { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          var configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

          optionsBuilder.UseSqlServer("Server=tcp:p2project.database.windows.net,1433;Initial Catalog=medProDB;Persist Security Info=False;User ID=project2;Password=Password@4567;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.ApptId)
                    .HasName("pk_apptId");

                entity.ToTable("appointments");

                entity.Property(e => e.ApptId).HasColumnName("apptId");

                entity.Property(e => e.DocId).HasColumnName("docId");

                entity.Property(e => e.PId).HasColumnName("pId");

                entity.Property(e => e.TimeId).HasColumnName("timeId");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_apptDocId");

                entity.HasOne(d => d.PIdNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_apptPId");

                entity.HasOne(d => d.Time)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.TimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_apptTimeId");
            });

            modelBuilder.Entity<Availability>(entity =>
            {
                entity.HasKey(e => e.AvailId)
                    .HasName("pk_availId");

                entity.ToTable("availability");

                entity.Property(e => e.AvailId).HasColumnName("availId");

                entity.Property(e => e.DocId).HasColumnName("docId");

                entity.Property(e => e.TimeId).HasColumnName("timeId");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.Availabilities)
                    .HasForeignKey(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_availDocId");

                entity.HasOne(d => d.Time)
                    .WithMany(p => p.Availabilities)
                    .HasForeignKey(d => d.TimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_availTimeId");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DocId)
                    .HasName("pk_docId");

                entity.ToTable("doctors");

                entity.Property(e => e.DocId).HasColumnName("docId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_docUserId");
            });

            modelBuilder.Entity<Doctorservice>(entity =>
            {
                entity.HasKey(e => e.DsId)
                    .HasName("pk_dsId");

                entity.ToTable("doctorservices");

                entity.Property(e => e.DsId).HasColumnName("dsId");

                entity.Property(e => e.DocId).HasColumnName("docId");

                entity.Property(e => e.SId).HasColumnName("sId");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.Doctorservices)
                    .HasForeignKey(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dsDocId");

                entity.HasOne(d => d.SIdNavigation)
                    .WithMany(p => p.Doctorservices)
                    .HasForeignKey(d => d.SId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dsSId");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("pk_pId");

                entity.ToTable("patients");

                entity.Property(e => e.PId).HasColumnName("pId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pUserId");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.SId)
                    .HasName("pk_sId");

                entity.ToTable("services");

                entity.Property(e => e.SId).HasColumnName("sId");

                entity.Property(e => e.SName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sName");

                entity.Property(e => e.TimeNeeded).HasColumnName("timeNeeded");
            });

            modelBuilder.Entity<Time>(entity =>
            {
                entity.ToTable("times");

                entity.Property(e => e.TimeId).HasColumnName("timeId");

                entity.Property(e => e.TimeEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("timeEnd");

                entity.Property(e => e.TimeStart)
                    .HasColumnType("datetime")
                    .HasColumnName("timeStart");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role).HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
