using MedicalConnected.Models;
using MedicalConnected.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalConnected.Controllers;


[ApiController]
[Route("api/[controller]")]
public class SpecialtyController : ControllerBase
{
    private readonly SpecialtySercive specialtySerive;

    public SpecialtyController(SpecialtySercive specialtySerive)
    {
        this.specialtySerive = specialtySerive;
    }

    [HttpPost]
    public async Task<Specialty> createSpecialty([FromBody] Specialty specialty)
    {
        if (specialty == null)
        {
            return null;
        }
        await specialtySerive.CreateSpecialty(specialty);
        return specialty;
        
    }

    [HttpGet]
    public async Task<IActionResult> GetSpecialties()
    {
        var specialties = await specialtySerive.GetSpecialties();

        if (specialties == null || specialties.Count == 0)
        {
            return NotFound(new { message = "No hay especialidades registradas." });
        }

        return Ok(specialties);
    }


    [HttpGet("{specialtyId}")]
    public async Task<IActionResult> GetSpecialty(int specialtyId)
    {
        var specialty = await specialtySerive.GetSpecialtyId(specialtyId);
    
        if (specialty == null)
        {
            return NotFound(new { message = "Especialidad no encontrada" });
        }

        return Ok(specialty);
    }
    
    
}