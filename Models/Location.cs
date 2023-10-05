using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapi.Models;

public class Location
{
    public Guid LocationId {get;set;}
    public string Name {get;set;}
    public string Description {get;set;}
    public string Address {get;set;}

    // [JsonIgnore]
    public virtual ICollection<Availability> Availabilities {get;set;}
}