using MedicalConnected.DbContext;
using MedicalConnected.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalConnected.Services
{
    public class CreateDoctorService
    {
        private readonly MedicalDbContext medicalDbContext;

        public CreateDoctorService(MedicalDbContext medicalDbContext)
        {
            this.medicalDbContext = medicalDbContext;
        }

        public async Task<Doctor> CreateDoctorAsync(Doctor doctor)
        {
            if (doctor is null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            medicalDbContext.Doctors.Add(doctor);
            await medicalDbContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> GetDoctorByIdAsync(int doctorId)
        {
            return await medicalDbContext.Doctors
                .FirstOrDefaultAsync(d => d.Id == doctorId);
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await medicalDbContext.Doctors.ToListAsync();
        }
    }
}