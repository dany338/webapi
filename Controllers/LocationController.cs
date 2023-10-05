using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace webapi.Controllers;

[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    protected readonly ILocationService _locationService;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;

        _jsonSerializerOptions = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            PropertyNamingPolicy = new ExcluirPropiedadNamingPolicy(new [] { "values", "$id" })
        };
    }

    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(_locationService.Get(), _jsonSerializerOptions);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Location location)
    {
        await _locationService.Add(location);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] Location location)
    {
        await _locationService.Update(id, location);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _locationService.Delete(id);
        return Ok();
    }
}

public class ExcluirPropiedadNamingPolicy : JsonNamingPolicy
{
    private readonly HashSet<string> _excludedPropertyNames;

    public ExcluirPropiedadNamingPolicy(IEnumerable<string> propiedadesAExcluir)
    {
        _excludedPropertyNames = new HashSet<string>(propiedadesAExcluir, StringComparer.OrdinalIgnoreCase);
    }

    public override string ConvertName(string name)
    {
        return _excludedPropertyNames.Contains(name) ? "" : name;
    }
}