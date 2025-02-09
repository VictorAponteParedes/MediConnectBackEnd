namespace MedicalConnected.Models;

public class DoctorSpeciality
{
    
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    
    
    public int SpecialityId { get; set; }
    public Specialty Specialty { get; set; }
}