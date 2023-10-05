using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models;

public class Availability
{
    public Guid AvailabilityId {get;set;}
    public Guid LocationId {get;set;}
    public TimeSpan InitTime {get;set;}
    public TimeSpan EndTime {get;set;}
    public virtual Location Location {get;set;}
}