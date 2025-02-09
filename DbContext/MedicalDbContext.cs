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
    public DbSet<DoctorSpeciality> DoctorSpecialities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DoctorSpeciality>()
            .HasKey(ds => new { ds.SpecialityId, ds.DoctorId });
        
        modelBuilder.Entity<DoctorSpeciality>()
            .HasOne(ds => ds.Doctor)
            .WithMany(d => d.DoctorSpecialities)
            .HasForeignKey(ds => ds.DoctorId);
        
        modelBuilder.Entity<DoctorSpeciality>()
            .HasOne(ds => ds.Specialty)
            .WithMany(s => s.DoctorSpecialities)
            .HasForeignKey(ds => ds.SpecialityId);
    }
}