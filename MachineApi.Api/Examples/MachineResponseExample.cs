using MachineApi.Api.Models;
using Swashbuckle.AspNetCore.Filters;

namespace MachineApi.Api.Examples;

public class MachineResponseExample : IExamplesProvider<List<Machine>>
{
    public List<Machine> GetExamples()
    {
        return new List<Machine>
        {
            new Machine
            {
                Id = 1,
                Name = "Caterpillar 320 Excavator",
                SerialNumber = "CAT320-8756-2022",
                Manufacturer = "Caterpillar Inc.",
                Location = "Construction Site A - North Yard"
            },
            new Machine
            {
                Id = 2,
                Name = "Komatsu D85 Bulldozer",
                SerialNumber = "KOM-D85-4291-2021",
                Manufacturer = "Komatsu Ltd.",
                Location = "Construction Site A - South Yard"
            }
        };
    }
}

