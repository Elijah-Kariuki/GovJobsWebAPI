using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using GovJobsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GovJobsWebAPI.Data
{
    public class JobDbContext : DbContext
    {
        public JobDbContext(DbContextOptions<JobDbContext> options) : base(options) { }

        public DbSet<JobViewModel> Jobs { get; set; }
        public DbSet<PositionLocation> PositionLocations { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<JobGrade> JobGrades { get; set; }
        public DbSet<PositionSchedule> PositionSchedules { get; set; }
        public DbSet<PositionOfferingType> PositionOfferingTypes { get; set; }
        public DbSet<PositionRemuneration> PositionRemunerations { get; set; }
        public DbSet<PositionFormattedDescription> PositionFormattedDescriptions { get; set; }
        public DbSet<WhoMayApply> WhoMayApplies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobViewModel>()
                .HasMany(j => j.PositionLocations)
                .WithOne()
                .HasForeignKey("PositionID");

            modelBuilder.Entity<JobViewModel>()
                .HasMany(j => j.JobCategories)
                .WithOne()
                .HasForeignKey("PositionID");

            modelBuilder.Entity<JobViewModel>()
                .HasMany(j => j.JobGrades)
                .WithOne()
                .HasForeignKey("PositionID");

            modelBuilder.Entity<JobViewModel>()
                .HasMany(j => j.PositionSchedules)
                .WithOne()
                .HasForeignKey("PositionID");

            modelBuilder.Entity<JobViewModel>()
                .HasMany(j => j.PositionOfferingTypes)
                .WithOne()
                .HasForeignKey("PositionID");

            modelBuilder.Entity<JobViewModel>()
                .HasMany(j => j.PositionRemunerations)
                .WithOne()
                .HasForeignKey("PositionID");

            modelBuilder.Entity<JobViewModel>()
                .HasMany(j => j.PositionFormattedDescriptions)
                .WithOne()
                .HasForeignKey("PositionID");

            modelBuilder.Entity<JobViewModel>()
                .HasOne(j => j.WhoMayApplies)
                .WithMany()
                .HasForeignKey("WhoMayApplyId");
        }
    }
}
