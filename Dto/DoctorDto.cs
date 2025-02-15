namespace MedicalConnected.Dto;

public class DoctorDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Photo  { get; set; }
    public DateTime DateOfBirth { get; set; }

    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public int? SpecialtyId { get; set; }
    public SpecialtyDto Specialty { get; set; }

}
