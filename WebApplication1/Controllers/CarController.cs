using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController(ICarService carService) : ControllerBase
{
    [HttpGet]
    public List<Car> GetAll()
    {
        var response = carService.GetAll();
        return response;
    }

    [HttpPost]
    public bool Create(Car car)
    {
        var response = carService.CreateCar(car);
        return response;
    }

    [HttpPut]
    public bool Update(Car car)
    {
        var response = carService.UpdateCar(car);
        return response;
    }

    [HttpDelete]
    public bool Delete(int id)
    {
        var response = carService.DeleteCar(id);
        return response;
    }
}