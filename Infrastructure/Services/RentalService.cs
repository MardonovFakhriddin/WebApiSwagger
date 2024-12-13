namespace Infrastructure.Services;

using System.Collections.Generic;
using DefaultNamespace;
using Domain.Models;
using Infrastructure.Interfaces;
using Dapper;
public class RentalService : IRentalService
{
    private readonly DapperContext _context;

    public RentalService(DapperContext context)
    {
        _context = context;
    }

    public List<Rental> GetAll()
    {
        using var context = _context.Connection();
        string cmd = "SELECT * FROM Rentals";
        var rentals = context.Query<Rental>(cmd).ToList();
        return rentals;
    }

    public Rental GetRentalById(int id)
    {
        using var context = _context.Connection();
        string cmd = "SELECT * FROM Rentals WHERE RentalId = @RentalId";
        var rental = context.QueryFirstOrDefault<Rental>(cmd, new { RentalId = id });
        return rental;
    }

    public bool CreateRental(Rental rental)
    {
        using var context = _context.Connection();
        var cmd = "INSERT INTO Rentals (CarId, CustomerId, StartDate, EndDate, TotalCost) VALUES (@CarId, @CustomerId, @StartDate, @EndDate, @TotalCost)";
        var response = context.Execute(cmd, rental);
        return response > 0;
    }

    public bool UpdateRental(Rental rental)
    {
        using var context = _context.Connection();
        var cmd = "UPDATE Rentals SET CarId = @CarId, CustomerId = @CustomerId, StartDate = @StartDate, EndDate = @EndDate, TotalCost = @TotalCost WHERE RentalId = @RentalId";
        var response = context.Execute(cmd, rental);
        return response > 0;
    }

    public bool DeleteRental(int id)
    {
        using var context = _context.Connection();
        var cmd = "DELETE FROM Rentals WHERE RentalId = @RentalId";
        var response = context.Execute(cmd, new { RentalId = id });
        return response != 0;
    }
}
