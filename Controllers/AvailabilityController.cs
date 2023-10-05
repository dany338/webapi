using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("api/[controller]")]
public class AvailabilityController : ControllerBase
{
  protected readonly IAvailabilityService _availabilityService;

  public AvailabilityController(IAvailabilityService availabilityService)
  {
    _availabilityService = availabilityService;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(_availabilityService.Get());
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] Availability availability)
  {
    await _availabilityService.Add(availability);
    return Ok();
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Put(Guid id, [FromBody] Availability availability)
  {
    await _availabilityService.Update(id, availability);
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    await _availabilityService.Delete(id);
    return Ok();
  }
}