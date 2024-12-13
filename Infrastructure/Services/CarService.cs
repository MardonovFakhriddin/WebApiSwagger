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

  public  List<Car> GetAll()
  {
    using var context = _context.Connection();
    string cmd = "SELECT * FROM Cars";
    var cars = context.Query<Car>(cmd).ToList();
    return cars;
  }

  public Car GetCarById(int id)
  {
    using var context = _context.Connection();
    string cmd = "SELECT * FROM Cars WHERE id = @id";
    var cars = context.QueryFirstOrDefault<Car>(cmd,new {Id = id});
    return cars;
  }


  public bool CreateCar(Car car)
  {
    using var context = _context.Connection();
    var cmd = "INSERT INTO Cars (Model, Manufacturer, Year, PricePerDay) VALUES (@Model, @Manufacturer, @Year, @PricePerDay)";
    var response = context.Execute(cmd, car);
    return response > 0;
  }

  public bool UpdateCar(Car car)
  {
    using var context = _context.Connection();
    var cmd = "UPDATE Cars SET Model = @Model, Manufacturer = @Manufacturer, Year = @Year, PricePerDay = @PricePerDay WHERE CarId = @CarId";
    var response = context.Execute(cmd, car);
    return response > 0;
  }

  public bool DeleteCar(int id)
  {
    using var context = _context.Connection();
    var cmd = "DELETE FROM Cars WHERE CarId = @CarId";
    var response = context.Execute(cmd, new { CarId = id });
    return response != 0;
  }
}
