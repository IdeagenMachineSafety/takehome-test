using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using MachineApi.Api.Models;
using Xunit;

namespace MachineApi.Tests;

public class MachineApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public MachineApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetMachineList_ReturnsSuccessStatusCode()
    {
        // Act
        var response = await _client.GetAsync("/api/machines");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetMachineList_ReturnsListOfMachines()
    {
        // Act
        var response = await _client.GetAsync("/api/machines");
        var machines = await response.Content.ReadFromJsonAsync<List<Machine>>();

        // Assert
        Assert.NotNull(machines);
        Assert.NotEmpty(machines);
        Assert.True(machines.Count > 0);
    }

    [Fact]
    public async Task GetMachineList_ReturnsMachinesWithRequiredProperties()
    {
        // Act
        var response = await _client.GetAsync("/api/machines");
        var machines = await response.Content.ReadFromJsonAsync<List<Machine>>();

        // Assert
        Assert.NotNull(machines);
        var firstMachine = machines.First();
        Assert.True(firstMachine.Id > 0);
        Assert.False(string.IsNullOrEmpty(firstMachine.Name));
        Assert.False(string.IsNullOrEmpty(firstMachine.SerialNumber));
        Assert.False(string.IsNullOrEmpty(firstMachine.Manufacturer));
    }

    [Fact]
    public async Task GetMachineList_ReturnsExpectedNumberOfSeededMachines()
    {
        // Act
        var response = await _client.GetAsync("/api/machines");
        var machines = await response.Content.ReadFromJsonAsync<List<Machine>>();

        // Assert
        Assert.NotNull(machines);
        Assert.Equal(5, machines.Count);
    }

    [Fact]
    public async Task GetMachineList_ReturnsJsonContentType()
    {
        // Act
        var response = await _client.GetAsync("/api/machines");

        // Assert
        Assert.Equal("application/json", response.Content.Headers.ContentType?.MediaType);
    }
}

