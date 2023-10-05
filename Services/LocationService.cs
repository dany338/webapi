using webapi;
using webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace webapi.Services;

public class LocationService : ILocationService
{
    private readonly AvailabilitiesContext _context;

    public LocationService(AvailabilitiesContext dbcontext)
    {
        _context = dbcontext;
    }

    public IEnumerable<Location> Get()
    {
        return _context.Locations.Include(l => l.Availabilities).ToList();
    }

    public async Task Add(Location location)
    {
        _context.Locations.Add(location);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Location location)
    {
        var locationToUpdate = _context.Locations.Find(id);
        if (locationToUpdate == null)
        {
            throw new Exception("Location not found");
        }
        locationToUpdate.Name = location.Name;
        locationToUpdate.Description = location.Description;
        locationToUpdate.Address = location.Address;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var locationToDelete = _context.Locations.Find(id);
        if (locationToDelete == null)
        {
            throw new Exception("Location not found");
        }
        _context.Locations.Remove(locationToDelete);
        await _context.SaveChangesAsync();
    }
}

public interface ILocationService
{
    IEnumerable<Location> Get();
    Task Add(Location location);
    Task Update(Guid id, Location location);
    Task Delete(Guid id);
}