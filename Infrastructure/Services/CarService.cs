using System.Net;
using Infrastructure.ApiResponse;

namespace Infrastructure.Services;

using System.Collections.Generic;
using DefaultNamespace;
using Domain.Models;
using Infrastructure.Interfaces;
using Dapper;
public class CarService : ICarService
{
  private readonly DapperContext _context;

  public CarService(DapperContext context)
  {
    _context = context;
  }

  public  Response<List<Car>> GetAll()
  {
    using var context = _context.Connection();
    string cmd = "SELECT * FROM Cars";
    var cars = context.Query<Car>(cmd).ToList();
    return new Response<List<Car>>(cars);
  }

  public Response<Car> GetCarById(int id)
  {
    using var context = _context.Connection();
    string cmd = "SELECT * FROM Cars WHERE id = @id";
    var cars = context.QueryFirstOrDefault<Car>(cmd,new {Id = id});
    return cars == null
      ? new Response<Car>(HttpStatusCode.NotFound, "Cars Not Found")
      : new Response<Car>(cars);
  }


  public Response<bool> CreateCar(Car car)
  {
    using var context = _context.Connection();
    var cmd = "INSERT INTO Cars (Model, Manufacturer, Year, PricePerDay) VALUES (@Model, @Manufacturer, @Year, @PricePerDay)";
    var response = context.Execute(cmd, car);
    return response == 0
      ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
      : new Response<bool>(HttpStatusCode.Created, "Car successfully created");
  }

  public Response<bool> UpdateCar(Car car)
  {
    using var context = _context.Connection();
    var existingCar = GetCarById(car.CarId).Data;
    if (existingCar == null)
    {
      return new Response<bool>(HttpStatusCode.NotFound, "Car not found");
    }
    var cmd = "UPDATE Cars SET Model = @Model, Manufacturer = @Manufacturer, Year = @Year, PricePerDay = @PricePerDay WHERE CarId = @CarId";
    var response = context.Execute(cmd, car);
    return response > 0
      ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal server error")
      : new Response<bool>(HttpStatusCode.OK, "Car successfully updated");
  }

  public Response<bool> DeleteCar(int id)
  {
    using var context = _context.Connection();
    var car = GetCarById(id).Data;
    if (car == null)
    {
      return new Response<bool>(HttpStatusCode.NotFound, "Car not found");
    }
    var cmd = "DELETE FROM Cars WHERE CarId = @CarId";
    var response = context.Execute(cmd, new { CarId = id });
    return response > 0
      ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal server error")
      : new Response<bool>(HttpStatusCode.OK, "Car successfully deleted");
  }
}
