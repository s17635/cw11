using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class CodeFirstContext : DbContext
    {
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Medicament> Medicament { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }

        public CodeFirstContext()
        {

        }

        public CodeFirstContext(DbContextOptions<CodeFirstContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient).HasName("Patient_PK");
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.BirthDate).IsRequired();
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription).HasName("Prescription_PK");
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.DueDate).IsRequired();
                entity.HasOne(e => e.Patient).WithMany(d => d.Prescriptions).HasForeignKey(p => p.IdPatient).HasConstraintName("Prescription_Patient_FK");
                entity.HasOne(e => e.Doctor).WithMany(p => p.Prescriptions).HasForeignKey(d => d.IdDoctor).HasConstraintName("Prescription_Doctor_FK");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor).HasName("Doctor_PK");
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.ToTable("Prescription_Medicament");
                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription });
                entity.Property(e => e.Dose).IsRequired(false);
                entity.Property(e => e.Details).HasMaxLength(100).IsRequired();
                entity.HasOne(e => e.Prescription).WithMany(d => d.PrescriptionMedicament).HasForeignKey(p => p.IdPrescription).HasConstraintName("Prescription_Medicament_Prescription_FK");
                entity.HasOne(e => e.Medicament).WithMany(p => p.PrescriptionMedicament).HasForeignKey(d => d.IdMedicament).HasConstraintName("Prescription_Medicament_Medicament_FK");
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament).HasName("Medicament_PK");
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Type).HasMaxLength(100).IsRequired();
            });
        }
    }
}
