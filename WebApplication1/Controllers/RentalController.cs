using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class RentalController(IRentalService rentalService): ControllerBase
{
    [HttpGet]
    public List<Rental> GetAll()
    {
        var response = rentalService.GetAll();
        return response;
    }

    [HttpPost]
    public bool CreateRental(Rental rental)
    {
        var response = rentalService.CreateRental(rental);
        return response;
    }

    [HttpPut]
    public bool UpdateRental(Rental rental)
    {
        var response = rentalService.UpdateRental(rental);
        return response;
    }

    [HttpDelete]
    public bool DeleteRental(int id)
    {
        var response = rentalService.DeleteRental(id);
        return response;
    }
}