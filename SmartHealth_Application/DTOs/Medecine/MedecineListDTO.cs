namespace SmartHealth_Application.DTOs.Medecine;

public record MedecineListDTO
{
    public int medecineID { get; set; }
    public string name { get; set; }
    public string quantity { get; set; }
    public string instructions { get; set; }
    public bool isBought { get; set; }
};