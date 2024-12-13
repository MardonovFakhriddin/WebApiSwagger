using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CarLocationController(ICarLocationService carLocationService) : ControllerBase
{
    [HttpGet]
    public Response<List<CarLocation>> GetAll()
    {
        var response = carLocationService.GetAll();
        return response;
    }

    [HttpPost("{id:int}")]
    public Response<CarLocation> GetCarLocationById( int id)
    {
        var response = carLocationService.GetCarLocationById( id);
        return response;
    }

    [HttpPost]
    public Response<bool> CreateCarLocation(CarLocation carLocation)
    {
        var response = carLocationService.CreateCarLocation(carLocation);
        return response;
    }

    [HttpPut]
    public Response<bool> UpdateCarLocation(CarLocation carLocation)
    {
        var response = carLocationService.UpdateCarLocation(carLocation);
        return response;
    }

    [HttpDelete]
    public Response<bool> DeleteCarLocation(int carId,int id)
    {
        var response = carLocationService.DeleteCarLocation(carId,id);
        return response;
    }
}