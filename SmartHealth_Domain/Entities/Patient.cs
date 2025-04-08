namespace SmartHealth_Domain.Entities;

public record Patient
{
    // ReSharper disable once InconsistentNaming
    public int PatientID { get; set; }
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public Address PersonalAdress { get; set; } = null!;
}