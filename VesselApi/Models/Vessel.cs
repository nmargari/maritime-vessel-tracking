namespace VesselApi.Models;

public class Vessel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string MMSI { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime LastUpdated { get; set; }
}