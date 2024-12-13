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

    public List<CarLocation> GetAll()
    {
        using var context = _context.Connection();
        string cmd = "SELECT * FROM CarLocations";
        var carLocations = context.Query<CarLocation>(cmd).ToList();
        return carLocations;
    }

    public CarLocation GetCarLocationById(int carId)
    {
        using var context = _context.Connection();
        string cmd = "SELECT * FROM CarLocations WHERE CarId = @CarId AND LocationId = @LocationId";
        var carLocation = context.QueryFirstOrDefault<CarLocation>(cmd, new { CarId = carId});
        return carLocation;
    }

    public bool CreateCarLocation(CarLocation carLocation)
    {
        using var context = _context.Connection();
        var cmd = "INSERT INTO CarLocations (CarId, LocationId) VALUES (@CarId, @LocationId)";
        var response = context.Execute(cmd, carLocation);
        return response > 0;
    }

    public bool UpdateCarLocation(CarLocation carLocation)
    {
        using var context = _context.Connection();
        var cmd = "UPDATE CarsLocations SET CarId=@CarId, LocationId=@LocationId WHERE CarId = @CarId";
        var response = context.Execute(cmd, carLocation);
        return response > 0;
    }

    public bool DeleteCarLocation(int carId, int id)
    {
        using var context = _context.Connection();
        var cmd = "DELETE FROM CarLocations WHERE CarId = @CarId AND id = @id";
        var response = context.Execute(cmd, new { CarId = carId, Id = id });
        return response != 0;
    }
}
