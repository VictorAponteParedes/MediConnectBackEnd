using MedicalConnected.Dto;
using MedicalConnected.Models;
using MedicalConnected.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalConnected.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorSpecialtyController : ControllerBase
{

    private readonly DoctorSpecialtyService doctorSpecialtyService;
    
    public DoctorSpecialtyController(DoctorSpecialtyService doctorSpecialtyService)
    {
        this.doctorSpecialtyService = doctorSpecialtyService;
    }

    [HttpPost]
    public async Task<IActionResult> AssingSpecialtyToDoctor([FromBody] AssignSpecialtyDto dto)
    {
        try
        {
            await doctorSpecialtyService.AssignSpecialtyToDoctorAsync(dto.DoctorId, dto.SpecialtyId);
            return Ok("Especialty assigned correctly");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
       
    }

    [HttpGet]
    public async Task<IActionResult> GetDoctorSpecialties()
    {
        var doctors = await doctorSpecialtyService.GetDoctorsWithSpecialtiesAsync();
        return Ok(doctors);
    }
    
    
    
}