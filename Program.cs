using webapi;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<AvailabilitiesContext>(builder.Configuration.GetConnectionString("AvailabilitiesContextLocal"));
// builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldService()); // Pass parameters to the constructor
builder.Services.AddScoped<IAvailabilityService, AvailabilityService>();
builder.Services.AddScoped<ILocationService, LocationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// app.UseWelcomePage();

// app.UseTimeMiddleware();

app.MapControllers();

app.Run();