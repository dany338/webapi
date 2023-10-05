using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi;

public class AvailabilitiesContext: DbContext
{
    public DbSet<Location> Locations {get;set;}
    public DbSet<Availability> Availabilities {get;set;}

    public AvailabilitiesContext(DbContextOptions<AvailabilitiesContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Location> locationsInit = new List<Location>();
        locationsInit.Add(new Location() { LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Name = "Pharmacy", Description = "Pharmacy description", Address = "123 Main St."});
        locationsInit.Add(new Location() { LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Name = "Bakery,", Description = "Bakery description", Address = "123 Main St."});
        locationsInit.Add(new Location() { LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb403"), Name = "Barber Shop", Description = "Barber Shop", Address = "123 Main St."});
        locationsInit.Add(new Location() { LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb404"), Name = "Supermarket", Description = "Supermarket description", Address = "123 Main St."});
        locationsInit.Add(new Location() { LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb405"), Name = "Candy Store", Description = "Candy Store description", Address = "123 Main St."});
        locationsInit.Add(new Location() { LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb406"), Name = "Cinema Complex", Description = "Cinema Complex description", Address = "123 Main St."});
        locationsInit.Add(new Location() { LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb407"), Name = "Clothing Store", Description = "Clothing Store description", Address = "123 Main St."});
        locationsInit.Add(new Location() { LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb408"), Name = "Coffee Shop", Description = "Coffee Shop description", Address = "123 Main St."});
        locationsInit.Add(new Location() { LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb409"), Name = "Convenience Store", Description = "Convenience Store description", Address = "123 Main St."});
        locationsInit.Add(new Location() { LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), Name = "Department Store", Description = "Department Store description", Address = "123 Main St."});
        locationsInit.Add(new Location() { LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb411"), Name = "Florist", Description = "Florist description", Address = "123 Main St."});
        locationsInit.Add(new Location() { LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb412"), Name = "Furniture Store", Description = "Furniture Store description", Address = "123 Main St."});
        locationsInit.Add(new Location() { LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb413"), Name = "Gas Station", Description = "Gas Station description", Address = "123 Main St."});
        locationsInit.Add(new Location() { LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb414"), Name = "Gift Shop", Description = "Gift Shop description", Address = "123 Main St."});
        locationsInit.Add(new Location() { LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb415"), Name = "Grocery Store", Description = "Grocery Store description", Address = "123 Main St."});
        locationsInit.Add(new Location() { LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb416"), Name = "Hair Salon", Description = "Hair Salon description", Address = "123 Main St."});

        modelBuilder.Entity<Location>(location=>
        {
            location.ToTable("Location");
            location.HasKey(p=> p.LocationId);

            location.Property(p=> p.Name).IsRequired().HasMaxLength(150);

            location.Property(p=> p.Description).IsRequired(false);

            location.HasData(locationsInit);
        });

        List<Availability> availabilitiesInit = new List<Availability>();

        availabilitiesInit.Add(new Availability() { AvailabilityId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb430"), LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), InitTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(13, 0, 0) });
        availabilitiesInit.Add(new Availability() { AvailabilityId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb431"), LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), InitTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(12, 0, 0) });
        availabilitiesInit.Add(new Availability() { AvailabilityId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb432"), LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb403"), InitTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(12, 0, 0) });
        availabilitiesInit.Add(new Availability() { AvailabilityId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb433"), LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb404"), InitTime = new TimeSpan(10, 30, 0), EndTime = new TimeSpan(12, 0, 0) });
        availabilitiesInit.Add(new Availability() { AvailabilityId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb434"), LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb405"), InitTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(12, 0, 0) });
        availabilitiesInit.Add(new Availability() { AvailabilityId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb435"), LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb406"), InitTime = new TimeSpan(11, 0, 0), EndTime = new TimeSpan(12, 0, 0) });
        availabilitiesInit.Add(new Availability() { AvailabilityId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb436"), LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb407"), InitTime = new TimeSpan(11, 30, 0), EndTime = new TimeSpan(12, 30, 0) });
        availabilitiesInit.Add(new Availability() { AvailabilityId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb437"), LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb408"), InitTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(13, 0, 0) });
        availabilitiesInit.Add(new Availability() { AvailabilityId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb438"), LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb409"), InitTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(13, 0, 0) });
        availabilitiesInit.Add(new Availability() { AvailabilityId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb439"), LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), InitTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(13, 0, 0) });
        availabilitiesInit.Add(new Availability() { AvailabilityId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfba40"), LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb411"), InitTime = new TimeSpan(11, 40, 0), EndTime = new TimeSpan(13, 0, 0) });
        availabilitiesInit.Add(new Availability() { AvailabilityId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfba41"), LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb412"), InitTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(13, 0, 0) });
        availabilitiesInit.Add(new Availability() { AvailabilityId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfba42"), LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb413"), InitTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(13, 0, 0) });
        availabilitiesInit.Add(new Availability() { AvailabilityId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfba43"), LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb414"), InitTime = new TimeSpan(10, 40, 0), EndTime = new TimeSpan(13, 0, 0) });
        availabilitiesInit.Add(new Availability() { AvailabilityId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfba44"), LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb415"), InitTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(13, 0, 0) });
        availabilitiesInit.Add(new Availability() { AvailabilityId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfba45"), LocationId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb416"), InitTime = new TimeSpan(10, 30, 0), EndTime = new TimeSpan(11, 0, 0) });

        modelBuilder.Entity<Availability>(availability=>
        {
            availability.ToTable("Availability");
            availability.HasKey(p=> p.AvailabilityId);

            availability.HasOne(p=> p.Location).WithMany(p=> p.Availabilities).HasForeignKey(p=> p.LocationId);

            availability.Property(p=> p.InitTime).IsRequired();

            availability.Property(p=> p.EndTime).IsRequired();

            availability.HasData(availabilitiesInit);
        });
    }
}