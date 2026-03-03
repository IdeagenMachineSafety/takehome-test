using MachineApi.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MachineApi.Api.Data;

public class MachineDbContext : DbContext
{
    public MachineDbContext(DbContextOptions<MachineDbContext> options) : base(options)
    {
    }

    public DbSet<Machine> Machines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data - Large Plant Items
        modelBuilder.Entity<Machine>().HasData(
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
            },
            new Machine
            {
                Id = 3,
                Name = "Liebherr LTM 1300 Mobile Crane",
                SerialNumber = "LBH-LTM1300-1847-2023",
                Manufacturer = "Liebherr Group",
                Location = "Main Depot"
            },
            new Machine
            {
                Id = 4,
                Name = "Volvo A45G Articulated Dump Truck",
                SerialNumber = "VLV-A45G-6392-2020",
                Manufacturer = "Volvo Construction Equipment",
                Location = "Construction Site B - Quarry"
            },
            new Machine
            {
                Id = 5,
                Name = "JCB JS220 Tracked Excavator",
                SerialNumber = "JCB-JS220-9284-2023",
                Manufacturer = "JCB",
                Location = "Construction Site C - Harbor"
            }
        );
    }
}

