namespace MedicalConnected.Dto;

public class SpecialtyWithDoctorsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }

    public List<DoctorDto> Doctors { get; set; }
}
