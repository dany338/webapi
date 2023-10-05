using webapi;
using webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace webapi.Services;

public class AvailabilityService : IAvailabilityService
{
    private readonly AvailabilitiesContext _context;

    public AvailabilityService(AvailabilitiesContext dbcontext)
    {
        _context = dbcontext;
    }

    public IEnumerable<Availability> Get()
    {
        return _context.Availabilities.Include(a => a.Location).ToList();
    }

    public async Task Add(Availability availability)
    {
        _context.Availabilities.Add(availability);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Availability availability)
    {
        var availabilityToUpdate = _context.Availabilities.Find(id);
        if (availabilityToUpdate == null)
        {
            throw new Exception("Availability not found");
        }
        availabilityToUpdate.InitTime = availability.InitTime;
        availabilityToUpdate.EndTime = availability.EndTime;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var availabilityToDelete = _context.Availabilities.Find(id);
        if (availabilityToDelete == null)
        {
            throw new Exception("Availability not found");
        }
        _context.Availabilities.Remove(availabilityToDelete);
        await _context.SaveChangesAsync();
    }
}

public interface IAvailabilityService
{
    IEnumerable<Availability> Get();
    Task Add(Availability availability);
    Task Update(Guid id, Availability availability);
    Task Delete(Guid id);
}