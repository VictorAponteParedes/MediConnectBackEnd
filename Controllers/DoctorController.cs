using MedicalConnected.Models;
using MedicalConnected.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalConnected.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly CreateDoctorService createDoctorService;

        public DoctorController(CreateDoctorService createDoctorService)
        {
            this.createDoctorService = createDoctorService;
        }

        // Endpoint para crear un doctor
        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] Doctor doctor)
        {
            if (doctor is null)
            {
                return BadRequest("El objeto doctor es nulo.");
            }

            var createdDoctor = await createDoctorService.CreateDoctorAsync(doctor);
            // Devuelve 201 Created con la ruta para obtener el doctor creado
            return CreatedAtAction(nameof(GetDoctor), new { doctorId = createdDoctor.Id }, createdDoctor);
        }
        
        
        [HttpGet]
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await createDoctorService.GetDoctorsAsync();
        }

        // Endpoint para obtener un doctor por ID
        [HttpGet("{doctorId}")]
        public async Task<IActionResult> GetDoctor(int doctorId)
        {
            var doctor = await createDoctorService.GetDoctorByIdAsync(doctorId);
            if (doctor is null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
    }
}