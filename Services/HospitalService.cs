using MedicalConnected.DbContext;
using MedicalConnected.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalConnected.Services;

public class HospitalService
{
    private MedicalDbContext medicalDbContext;

    public HospitalService(MedicalDbContext medicalDbContext)
    {
        this.medicalDbContext = medicalDbContext;
    }

    public async Task<Hospital> CreateHospital(Hospital hospital)
    {
        if (hospital is null)
        {
            throw new ArgumentNullException("No puedes crear un Hospital");
        }
        
       await medicalDbContext.Hospitals.AddAsync(hospital);
       await medicalDbContext.SaveChangesAsync();
       return hospital;
       
    }

    public async Task<Hospital> GetHospitalById(int id)
    {
        try
        {
            var hospital = await medicalDbContext.Hospitals.FindAsync(id);
            return hospital;
        }
        catch (Exception e)
        {
            throw new Exception($"Hospital not found: {e.Message}");
           
        }
        
    }

    public async Task<List<Hospital>> GetHospitals()
    {
        try
        {
            return await medicalDbContext.Hospitals.ToListAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"Hospital not found: {e.Message}");
        }
    }
    
    
}