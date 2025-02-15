using MedicalConnected.DbContext;
using MedicalConnected.Dto;
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

        public async Task<Doctor> CreateDoctorAsync(Doctor doctor, int? specialtyId)
        {
            if (doctor is null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            // Si se proporciona un specialtyId, busca la especialidad
            if (specialtyId.HasValue)
            {
                var specialty = await medicalDbContext.Specialties.FindAsync(specialtyId.Value);
                if (specialty == null)
                {
                    throw new ArgumentException("Specialty not found");
                }

                // Asigna la especialidad al doctor
                doctor.SpecialtyId = specialtyId.Value;
            }

            // Guarda el doctor en la base de datos
            medicalDbContext.Doctors.Add(doctor);
            await medicalDbContext.SaveChangesAsync();

            return doctor;
        }

        public async Task<List<DoctorDto>> GetDoctorsAsync(int doctorId)
        {
            return await medicalDbContext.Doctors
                .Include(d => d.Specialty)
                .Select(d => new DoctorDto
                {
                    Id = d.Id,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Email = d.Email,
                    Address = d.Address,
                    PhoneNumber = d.PhoneNumber,
                    Photo = d.Photo,
                    DateOfBirth = d.DateOfBirth,
                    CreateAt = d.CreateAt,
                    UpdateAt = d.UpdatedAt,
                    SpecialtyId = d.SpecialtyId,
                    Specialty = d.Specialty != null
                        ? new SpecialtyDto
                        {
                            Id = d.Specialty.Id,
                            Name = d.Specialty.Name,
                            Description = d.Specialty.Description,
                            CreateAt = d.CreateAt,
                            UpdateAt = d.UpdatedAt,
                        }
                        : null


                }).ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int doctorId)
        {
            return await medicalDbContext.Doctors
                .Include(d => d.Specialty) // Incluye la especialidad
                .FirstOrDefaultAsync(d => d.Id == doctorId);
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await medicalDbContext.Doctors
                .Include(d => d.Specialty) // Incluye la especialidad
                .ToListAsync();
        }
    }
}
