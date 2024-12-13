using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]

public class RentalController(IRentalService rentalService): ControllerBase
{
    [HttpGet]
    public Response<List<Rental>> GetAll()
    {
        var response = rentalService.GetAll();
        return response;
    }

    [HttpPost("{id:int}")]
    public Response<Rental> GetLocationById(int id)
    {
        var response = rentalService.GetRentalById(id);
        return response;
    }
    [HttpPost]
    public Response<bool> CreateRental(Rental rental)
    {
        var response = rentalService.CreateRental(rental);
        return response;
    }

    [HttpPut]
    public Response<bool> UpdateRental(Rental rental)
    {
        var response = rentalService.UpdateRental(rental);
        return response;
    }

    [HttpDelete]
    public Response<bool> DeleteRental(int id)
    {
        var response = rentalService.DeleteRental(id);
        return response;
    }
}