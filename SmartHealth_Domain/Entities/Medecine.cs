namespace SmartHealth_Domain.Entities;

public record Medecine
{
    public int MedecineID { get; set; }
    public string Name { get; set; }
    public string Quantity { get; set; }
    public string? Instructions { get; set; }
    public DateTime Date { get; set; }
    public bool isBought { get; set; }
    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }
    public Appointment? Appointment { get; set; }
};