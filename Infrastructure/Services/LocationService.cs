using System.Net;
using Infrastructure.ApiResponse;

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

    public Response<List<Location>> GetAll()
    {
        using var context = _context.Connection();
        string cmd = "SELECT * FROM Locations";
        var locations = context.Query<Location>(cmd).ToList();
        return new Response<List<Location>>(locations);
    }

    public Response<Location> GetLocationById(int id)
    {
        using var context = _context.Connection();
        string cmd = "SELECT * FROM Locations WHERE LocationId = @LocationId";
        var location = context.QueryFirstOrDefault<Location>(cmd, new { LocationId = id });
        return location == null
            ? new Response<Location>(HttpStatusCode.NotFound, "Location Not Found")
            : new Response<Location>(location);
    }

    public Response<bool> CreateLocation(Location location)
    {
        using var context = _context.Connection();
        var cmd = "INSERT INTO Locations (City, Address) VALUES (@City, @Address)";
        var response = context.Execute(cmd, location);
        return response == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.Created, "Location successfully created");
    }

    public Response<bool> UpdateLocation(Location location)
    {
        using var context = _context.Connection();
        var existingLocation = GetLocationById(location.LocationId).Data;
        if (existingLocation == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Location not found");
        }
        var cmd = "UPDATE Locations SET City = @City, Address = @Address WHERE LocationId = @LocationId";
        var response = context.Execute(cmd, location);
        return response > 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Response<bool>(HttpStatusCode.OK, "Location successfully updated");
    }

    public Response<bool> DeleteLocation(int id)
    {
        using var context = _context.Connection();
        var location = GetLocationById(id).Data;
        if (location == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Location not found");
        }
        var cmd = "DELETE FROM Locations WHERE LocationId = @LocationId";
        var response = context.Execute(cmd, new { LocationId = id });
        return response > 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Response<bool>(HttpStatusCode.OK, "Location successfully deleted");
    }
}
