namespace MachineApi.Api.Models;

public class Machine
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string SerialNumber { get; set; }
    public required string Manufacturer { get; set; }
    public string? Location { get; set; }
}

