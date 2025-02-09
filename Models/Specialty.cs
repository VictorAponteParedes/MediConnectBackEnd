using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalConnected.Models;

public class Specialty
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Create_at { get; set; }
    public DateTime Update_at { get; set; }
    
    public ICollection<DoctorSpeciality> DoctorSpecialities { get; set; } = new List<DoctorSpeciality>();
}