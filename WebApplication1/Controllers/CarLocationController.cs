using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CarLocationController(ICarLocationService carLocationService) : ControllerBase
{
    [HttpGet]
    public List<CarLocation> GetAll()
    {
        var response = carLocationService.GetAll();
        return response;
    }

    [HttpPost]
    public bool CreateCarLocation(CarLocation carLocation)
    {
        var response = carLocationService.CreateCarLocation(carLocation);
        return response;
    }

    [HttpPut]
    public bool UpdateCarLocation(CarLocation carLocation)
    {
        var response = carLocationService.UpdateCarLocation(carLocation);
        return response;
    }

    [HttpDelete]
    public bool DeleteCarLocation(int carId,int id)
    {
        var response = carLocationService.DeleteCarLocation(carId,id);
        return response;
    }
}