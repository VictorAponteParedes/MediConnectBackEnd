using MedicalConnected.Models;
using MedicalConnected.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalConnected.Controllers;


[ApiController]
[Route("api/[controller]")]
public class HospitalController : ControllerBase
{
    private readonly HospitalService hospitalService;

    public HospitalController(HospitalService hospitalService)
    {
        this.hospitalService = hospitalService;
    }

    [HttpPost]
    public async Task<ActionResult<Hospital>> CreateHospital(Hospital hospital)
    {
        try
        {
            var hospitalCreated = await hospitalService.CreateHospital(hospital);
            return hospitalCreated;
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocurrió un error al crear el hospital.");
        }
    }


    [HttpGet]
    public Task<List<Hospital>> getAllHospitals()
    {
        return  hospitalService.GetHospitals();
    }




}
