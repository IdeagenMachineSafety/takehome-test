using MachineApi.Api.Data;
using MachineApi.Api.Examples;
using MachineApi.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;

namespace MachineApi.Api.Endpoints
{
    public static class GetMachinesEndpoint
    {
        public static RouteGroupBuilder GetMachinesRoute(this RouteGroupBuilder routeGroupBuilder)
        {
            routeGroupBuilder
                .MapGet("/machines", GetMachines)
                .WithName("GetMachineList")
                .WithTags("Machines")
                .WithSummary("Retrieve a list of machines")
                .Produces<List<Machine>>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound);

            return routeGroupBuilder;
        }

        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(MachineResponseExample))]
        [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(ProblemDetails400ResponseExample))]
        [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(ProblemDetails404ResponseExample))]
        public static async Task<Results<BadRequest<ProblemDetails>, NotFound<ProblemDetails>, Ok<List<Machine>>>> GetMachines(
            MachineDbContext db)
        {
            var machines = await db.Machines.ToListAsync();

            return TypedResults.Ok(machines);
        }
    }
}
