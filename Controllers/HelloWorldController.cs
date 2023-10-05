using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;

    AvailabilitiesContext dbcontext;

    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(ILogger<HelloWorldController> logger, IHelloWorldService helloWorld, AvailabilitiesContext db)
    {
        _logger = logger;
        helloWorldService = helloWorld;
        dbcontext = db;
    }


    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Saludando el mundo");
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        _logger.LogInformation("Creando la base de datos");
        dbcontext.Database.EnsureCreated();
        return Ok("Base de datos creada");
    }
}