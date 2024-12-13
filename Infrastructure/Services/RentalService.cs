using System.Net;
using Infrastructure.ApiResponse;

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

    public Response<List<Rental>> GetAll()
    {
        using var context = _context.Connection();
        string cmd = "SELECT * FROM Rentals";
        var rentals = context.Query<Rental>(cmd).ToList();
        return new Response<List<Rental>>(rentals);
    }

    public Response<Rental> GetRentalById(int id)
    {
        using var context = _context.Connection();
        string cmd = "SELECT * FROM Rentals WHERE RentalId = @RentalId";
        var rental = context.QueryFirstOrDefault<Rental>(cmd, new { RentalId = id });
        return rental == null
            ? new Response<Rental>(HttpStatusCode.NotFound, "Rental Not Found")
            : new Response<Rental>(rental);
    }

    public Response<bool> CreateRental(Rental rental)
    {
        using var context = _context.Connection();
        var cmd =
            "INSERT INTO Rentals (CarId, CustomerId, StartDate, EndDate, TotalCost) VALUES (@CarId, @CustomerId, @StartDate, @EndDate, @TotalCost)";
        var response = context.Execute(cmd, rental);
        return response == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.Created, "Rental successfully created");
    }

    public Response<bool> UpdateRental(Rental rental)
    {
        using var context = _context.Connection();
        var existingRental = GetRentalById(rental.RentalId).Data;
        if (existingRental == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Rental not found");
        }

        var cmd =
            "UPDATE Rentals SET CarId = @CarId, CustomerId = @CustomerId, StartDate = @StartDate, EndDate = @EndDate, TotalCost = @TotalCost WHERE RentalId = @RentalId";
        var response = context.Execute(cmd, rental);
        return response > 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Response<bool>(HttpStatusCode.OK, "Rental successfully updated");
    }

    public Response<bool> DeleteRental(int id)
    {
        using var context = _context.Connection();
        var rental = GetRentalById(id).Data;
        if (rental == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Rental not found");
        }
        var cmd = "DELETE FROM Rentals WHERE RentalId = @RentalId";
        var response = context.Execute(cmd, new { RentalId = id });
        return response > 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Response<bool>(HttpStatusCode.OK, "Rental successfully deleted");
    }
}