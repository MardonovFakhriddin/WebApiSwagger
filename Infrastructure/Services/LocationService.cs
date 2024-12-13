namespace Infrastructure.Services;

using System.Collections.Generic;
using DefaultNamespace;
using Domain.Models;
using Infrastructure.Interfaces;
using Dapper;

public class LocationService : ILocationService
{
    private readonly DapperContext _context;

    public LocationService(DapperContext context)
    {
        _context = context;
    }

    public List<Location> GetAll()
    {
        using var context = _context.Connection();
        string cmd = "SELECT * FROM Locations";
        var locations = context.Query<Location>(cmd).ToList();
        return locations;
    }

    public Location GetLocationById(int id)
    {
        using var context = _context.Connection();
        string cmd = "SELECT * FROM Locations WHERE LocationId = @LocationId";
        var location = context.QueryFirstOrDefault<Location>(cmd, new { LocationId = id });
        return location;
    }

    public bool CreateLocation(Location location)
    {
        using var context = _context.Connection();
        var cmd = "INSERT INTO Locations (City, Address) VALUES (@City, @Address)";
        var response = context.Execute(cmd, location);
        return response > 0;
    }

    public bool UpdateLocation(Location location)
    {
        using var context = _context.Connection();
        var cmd = "UPDATE Locations SET City = @City, Address = @Address WHERE LocationId = @LocationId";
        var response = context.Execute(cmd, location);
        return response > 0;
    }

    public bool DeleteLocation(int id)
    {
        using var context = _context.Connection();
        var cmd = "DELETE FROM Locations WHERE LocationId = @LocationId";
        var response = context.Execute(cmd, new { LocationId = id });
        return response != 0;
    }
}
