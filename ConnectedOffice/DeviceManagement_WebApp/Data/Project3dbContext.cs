﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DeviceManagement_WebApp.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DeviceManagement_WebApp.Data
{
    public partial class Project3dbContext : DbContext
    {
        public Project3dbContext()
        {
        }

        public Project3dbContext(DbContextOptions<Project3dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Zone> Zone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:cmpg323p3.database.windows.net,1433;Initial Catalog=Project3db;Persist Security Info=False;User ID=admindb;Password=CMPG323@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductDescription).IsUnicode(false);

                entity.Property(e => e.ProductName).IsUnicode(false);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.ServiceId)
                    .HasColumnName("ServiceID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceDescription).IsUnicode(false);

                entity.Property(e => e.ServiceName).IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName).IsRequired();

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.DeviceId)
                    .HasColumnName("DeviceID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ZoneId).HasColumnName("ZoneID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Device_Category");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName("FK_Device_Zone");
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.Property(e => e.ZoneId)
                    .HasColumnName("ZoneID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ZoneName).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
