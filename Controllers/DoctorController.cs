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
        public async Task<IActionResult> CreateDoctor([FromBody] Doctor doctor, [FromQuery] int? specialtyId)
        {
            if (doctor is null)
            {
                return BadRequest("El objeto doctor es nulo.");
            }

            // Deshabilita la validación automática
            ModelState.Clear();

            try
            {
                // Llama al servicio para crear el doctor y asignar la especialidad
                var createdDoctor = await createDoctorService.CreateDoctorAsync(doctor, specialtyId);

                // Devuelve 201 Created con la ruta para obtener el doctor creado
                return CreatedAtAction(nameof(GetDoctor), new { doctorId = createdDoctor.Id }, createdDoctor);
            }
            catch (ArgumentException ex)
            {
                // Maneja el caso en que la especialidad no exista
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Maneja otros errores
                return StatusCode(500, "Ocurrió un error interno al crear el doctor.");
            }
        }

        [HttpGet("with-specialty")]
        public async Task<IActionResult> GetDoctorsWithSpecialties()
        {
            var getDoctorsWithSpecialties = await createDoctorService.GetDoctorsAsync();
            return Ok(getDoctorsWithSpecialties);
        }


        // Endpoint para obtener todos los doctores
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await createDoctorService.GetDoctorsAsync();
            return Ok(doctors);
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
