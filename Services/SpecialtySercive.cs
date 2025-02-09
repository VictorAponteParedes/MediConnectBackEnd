using MedicalConnected.DbContext;
using MedicalConnected.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalConnected.Services;

public class SpecialtySercive
{
    private readonly MedicalDbContext medicalDbContext;

    public SpecialtySercive(MedicalDbContext medicalDbContext)
    {
        this.medicalDbContext = medicalDbContext;
    }

    public async Task<Specialty> CreateSpecialty(Specialty specialty)
    {
        if (specialty is null)
        {
            throw new ArgumentNullException(nameof(specialty));
        }
        await medicalDbContext.Specialties.AddAsync(specialty);
        await medicalDbContext.SaveChangesAsync();
        return specialty;
        
    }

    public async Task<Specialty?> GetSpecialtyId(int specialtyId)
    {
        if (specialtyId <= 0)
        {
            throw new ArgumentException("ID de especialidad inválido.", nameof(specialtyId));
        }

        var specialty = await medicalDbContext.Specialties
            .FirstOrDefaultAsync(s => s.Id == specialtyId);

        return specialty;
    }

    public async Task<List<Specialty>> GetSpecialties()
    {
        return await medicalDbContext.Specialties.ToListAsync();
    }
}