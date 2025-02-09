using System.Runtime.InteropServices.JavaScript;

namespace MedicalConnected.Models;

public class Patient
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; } 
    public string PhoneNumber { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime Create_at { get; set; }
    public DateTime Updated_at { get; set; }
    
}