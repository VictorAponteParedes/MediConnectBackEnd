using MedicalConnected.DbContext;
using MedicalConnected.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalConnected.Services;

public class DoctorSpecialtyService
{
    private MedicalDbContext medicalDbContext;

    public DoctorSpecialtyService(MedicalDbContext medicalDbContext)
    {
        this.medicalDbContext = medicalDbContext;
    }

    public async Task AssignSpecialtyToDoctorAsync(int doctorId, int specialtyId)
    {
        var doctor = await medicalDbContext.Doctors.FindAsync(doctorId);
        var specialty = await medicalDbContext.Specialties.FindAsync(specialtyId);

        if (doctor == null || specialty == null)
        {
            throw new Exception("Doctor o Especialidad no encontrados.");
        }

        var doctorSpecialty = new DoctorSpeciality()
        {
            DoctorId = doctorId,
            SpecialityId = specialtyId,
        };
        
        medicalDbContext.DoctorSpecialities.Add(doctorSpecialty);
        medicalDbContext.SaveChangesAsync();

    }

    public async Task<IEnumerable<Doctor>> GetDoctorsWithSpecialtiesAsync()
    {
        return await medicalDbContext.Doctors
            .Include(d => d.DoctorSpecialities)
            .ThenInclude(ds => ds.Specialty)
            .ToListAsync();
    }
}