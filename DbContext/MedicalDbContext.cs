using MedicalConnected.Models;

namespace MedicalConnected.DbContext;
using Microsoft.EntityFrameworkCore;

public class MedicalDbContext: DbContext

{
    public MedicalDbContext(DbContextOptions<MedicalDbContext> options) : base(options)
    {

    }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Specialty> Specialties { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>()
            .HasOne(d => d.Specialty) // Un doctor tiene una especialidad
            .WithMany() // Una especialidad puede tener muchos doctores
            .HasForeignKey(d => d.SpecialtyId) // Clave foránea
            .IsRequired(false); // La relación es opcional

        modelBuilder.Entity<Specialty>()
            .HasMany(s => s.Doctors)
            .WithOne(d => d.Specialty)
            .HasForeignKey(d => d.SpecialtyId)
            .IsRequired(false);

    }
}
