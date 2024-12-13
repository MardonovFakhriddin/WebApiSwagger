using System.Net;
using Infrastructure.ApiResponse;

namespace Infrastructure.Services;

using System.Collections.Generic;
using DefaultNamespace;
using Domain.Models;
using Infrastructure.Interfaces;
using Dapper;
public class CarLocationService : ICarLocationService
{
    private readonly DapperContext _context;

    public CarLocationService(DapperContext context)
    {
        _context = context;
    }

    public Response<List<CarLocation>> GetAll()
    {
        using var context = _context.Connection();
        string cmd = "SELECT * FROM CarLocations";
        var carLocations = context.Query<CarLocation>(cmd).ToList();
        return new Response<List<CarLocation>>(carLocations);
    }

    public Response<CarLocation> GetCarLocationById(int carId)
    {
        using var context = _context.Connection();
        string cmd = "SELECT * FROM CarLocations WHERE CarId = @CarId AND LocationId = @LocationId";
        var carLocation = context.QueryFirstOrDefault<CarLocation>(cmd, new { CarId = carId});
        return carLocation == null
            ? new Response<CarLocation>(HttpStatusCode.NotFound, "CarLocation Not Found")
            : new Response<CarLocation>(carLocation);
    }

    public Response<bool> CreateCarLocation(CarLocation carLocation)
    {
        using var context = _context.Connection();
        var cmd = "INSERT INTO CarLocations (CarId, LocationId) VALUES (@CarId, @LocationId)";
        var response = context.Execute(cmd, carLocation);
        return response == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.Created, "CarLocation successfully created");
    }

    public Response<bool> UpdateCarLocation(CarLocation carLocation)
    {
        using var context = _context.Connection();
        var existingCarLocation = GetCarLocationById(carLocation.CarId).Data;
        if (existingCarLocation == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "CarLocation not found");
        }
        var cmd = "UPDATE CarsLocations SET CarId=@CarId, LocationId=@LocationId WHERE CarId = @CarId";
        var response = context.Execute(cmd, carLocation);
        return response > 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Response<bool>(HttpStatusCode.OK, "CarLocation successfully updated");
    }

    public Response<bool> DeleteCarLocation(int carId, int id)
    {
        using var context = _context.Connection();
        var carLocation = GetCarLocationById(id).Data;
        if (carLocation == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "CarLocation not found");
        }
        var cmd = "DELETE FROM CarLocations WHERE CarId = @CarId AND id = @id";
        var response = context.Execute(cmd, new { CarId = carId, Id = id });
        return response > 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Response<bool>(HttpStatusCode.OK, "CarLocation successfully deleted");
    }
}
