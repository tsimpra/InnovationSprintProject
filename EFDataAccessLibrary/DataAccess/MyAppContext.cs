using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccessLibrary.DataAccess
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<MorbidityGroup> MorbidityGroups { get; set; }
        public DbSet<SymptomInstance> SymptomInstances { get; set; }

        public DbSet<PatientMorbidityGroup> PatientMorbidityGroups { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<MorbidityGroup>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<SymptomInstance>()
                .HasKey(x => x.Id);

            //Setting up the Many-to-many relationship between patient and morbidity groups

            modelBuilder.Entity<PatientMorbidityGroup>()
                .HasKey(x => new { x.PatientId, x.MorbidityGroupId });

            modelBuilder.Entity<PatientMorbidityGroup>()
                .HasOne(x => x.Patient)
                .WithMany(m => m.MorbidityGroups)
                .HasForeignKey(x => x.PatientId);
            modelBuilder.Entity<PatientMorbidityGroup>()
                .HasOne(x => x.MorbidityGroup)
                .WithMany(e => e.Patients)
                .HasForeignKey(x => x.MorbidityGroupId);

            //Add uniqueness constraint for name on MorbidityGroup and SymptomInstance
            modelBuilder.Entity<MorbidityGroup>().HasIndex(s => s.Name).IsUnique();
            modelBuilder.Entity<SymptomInstance>().HasIndex(s => s.Name).IsUnique();

        }
    }
}
