# Machine API - Take Home Assignment

A simple .NET Core minimal API for managing machine inventory.

## Features

- ✅ **Minimal API** - Built with .NET 9 minimal API architecture
- ✅ **Swagger Documentation** - Interactive API documentation at root URL
- ✅ **Entity Framework Core** - Data access with EF Core
- ✅ **In-Memory Database** - SQL Server in-memory database for development
- ✅ **XUnit Testing** - Comprehensive integration tests
- ✅ **Seeded Data** - Pre-populated with sample machine data

## 🎯 Assessment Exercises

This take-home assessment includes multiple exercises to evaluate different aspects of senior engineering skills:

### 1. **Story Implementation** (2-3 hours)

**[STORY: MACH-102 - Update Machine Location](STORY_UPDATE_MACHINE_LOCATION.md)**

Implement a PATCH endpoint to update a machine's location following established patterns.

**Skills Assessed:**

- API development
- Pattern adherence
- Validation implementation
- Testing practices
- Swagger documentation

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- An IDE (Visual Studio, VS Code, or Rider)

## Project Structure

```
MachineApi/
├── MachineApi.Api/                    # Main API project
│   ├── Data/                          # Database context
│   │   └── MachineDbContext.cs        # EF Core DbContext with seed data
│   ├── Endpoints/                     # API endpoints
│   │   └── GetMachines.cs             # GET /api/machines endpoint
│   ├── Examples/                      # Swagger response examples
│   │   ├── MachineResponseExample.cs
│   │   ├── ProblemDetails400ResponseExample.cs
│   │   └── ProblemDetails404ResponseExample.cs
│   ├── Models/                        # Data models
│   │   └── Machine.cs                 # Machine entity
│   └── Program.cs                     # Application entry point & configuration
├── MachineApi.Tests/                  # XUnit test project
│   └── MachineApiTests.cs             # Integration tests
└── MachineApi.sln                     # Solution file
```

## Getting Started

### 1. Clone or Extract the Project

### 2. Restore Dependencies

### 3. Build the Solution

### 4. Run the API

The API will start and display URLs like:

```
Now listening on: http://localhost:5217
Now listening on: https://localhost:7199
```

### 5. Access Swagger UI

The Swagger UI is automatically configured at the root URL:

- `https://localhost:7199` (HTTPS - recommended)
- `http://localhost:5217` (HTTP)

When using Visual Studio (F5), the browser will open automatically to the Swagger UI, providing interactive API documentation.

## API Endpoints

### Get Machine List

**Endpoint:** `GET /api/machines`

**Description:** Retrieves a list of all machines with their identifiers

**Response Example:**

```json
[
  {
    "id": 1,
    "name": "Caterpillar 320 Excavator",
    "serialNumber": "CAT320-8756-2022",
    "manufacturer": "Caterpillar Inc.",
    "location": "Construction Site A - North Yard",
    "installationDate": "2022-03-15T00:00:00"
  },
  {
    "id": 2,
    "name": "Komatsu D85 Bulldozer",
    "serialNumber": "KOM-D85-4291-2021",
    "manufacturer": "Komatsu Ltd.",
    "location": "Construction Site A - South Yard",
    "installationDate": "2021-08-22T00:00:00"
  }
]
```

## Running Tests

Execute the XUnit tests with:

```bash
dotnet test
```

The test suite includes:

- ✅ Status code validation
- ✅ Response data verification
- ✅ Required property checks
- ✅ Seeded data validation
- ✅ Content type validation

## Database

The application uses **Entity Framework Core with an in-memory database** that is automatically seeded with 5 large plant items on startup:

1. Caterpillar 320 Excavator
2. Komatsu D85 Bulldozer
3. Liebherr LTM 1300 Mobile Crane
4. Volvo A45G Articulated Dump Truck
5. JCB JS220 Tracked Excavator

The in-memory database is recreated each time the application starts, ensuring a clean state for testing and development.

## Technologies Used

- **.NET 9** - Latest .NET framework
- **ASP.NET Core Minimal API** - Lightweight API framework
- **Entity Framework Core 9** - ORM for database access
- **EF Core In-Memory Provider** - In-memory database for development
- **Swashbuckle.AspNetCore** - Swagger/OpenAPI documentation
- **Swashbuckle.AspNetCore.Filters** - Swagger response examples
- **XUnit** - Testing framework
- **Microsoft.AspNetCore.Mvc.Testing** - Integration testing support

## Development Notes

### Key Design Decisions

1. **Minimal API**: Chosen for simplicity and modern .NET approach
2. **Organized Endpoint Structure**: Endpoints extracted to separate classes in the `Endpoints` folder for better maintainability
3. **In-Memory Database**: Allows running without external database dependencies
4. **Seeded Data**: Provides immediate data for testing and exploration
5. **Swagger at Root**: Convenient access to API documentation
6. **Response Examples**: Uses Swashbuckle.AspNetCore.Filters for rich Swagger documentation with example responses

### Machine Model

The `Machine` entity includes the following properties:

- `Id` (int) - Primary key, auto-generated
- `Name` (string, required) - Machine name
- `SerialNumber` (string, required) - Unique serial identifier
- `Manufacturer` (string, required) - Manufacturer name
- `Location` (string, optional) - Physical location
- `InstallationDate` (DateTime) - Installation date

## License

This project is provided as-is for assessment purposes.
