using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController(ICarService carService) : ControllerBase
{
    [HttpGet]
    public Response<List<Car>> GetAll()
    {
        var response = carService.GetAll();
        return response;
    }
    [HttpPost("{id:int}")]
    public Response<Car> GetCarById(int id)
    {
        var response = carService.GetCarById(id);
        return response;
    }

    [HttpPost]
    public Response<bool> Create(Car car)
    {
        var response = carService.CreateCar(car);
        return response;
    }

    [HttpPut]
    public Response<bool> Update(Car car)
    {
        var response = carService.UpdateCar(car);
        return response;
    }

    [HttpDelete]
    public Response<bool> Delete(int id)
    {
        var response = carService.DeleteCar(id);
        return response;
    }
}