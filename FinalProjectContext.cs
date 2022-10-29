using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalProject.Models
{
    public partial class FinalProjectContext : DbContext
    {
        public FinalProjectContext()
        {
        }

        public FinalProjectContext(DbContextOptions<FinalProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appartment> Appartments { get; set; } = null!;
        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Tenant> Tenants { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=AKSHAR;Database=FinalProject;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appartment>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.RentalPrice).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Appartments)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("FK_Appartments_Buildings");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasOne(d => d.Appartment)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.AppartmentId)
                    .HasConstraintName("FK_Appointments_Appartments");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Appointments_Employees");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK_Appointments_Tenants");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(25);

                entity.Property(e => e.PostalCode).HasMaxLength(7);

                entity.Property(e => e.Province).HasMaxLength(25);

                entity.Property(e => e.StreetName).HasMaxLength(100);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Buildings_Employees");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.EmployeeType).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(200);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Queries).HasMaxLength(500);

                entity.Property(e => e.QueryDate).HasColumnType("date");

                entity.Property(e => e.Response).HasMaxLength(500);

                entity.Property(e => e.ResponseDate).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Messages_Employees");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK_Messages_Tenants");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(200);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Users_UserRoles");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.Role).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
