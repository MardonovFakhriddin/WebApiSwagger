namespace Infrastructure.Interfaces; 
using Domain.Models;
public interface ICarService
{
        List<Car> GetAll();
        Car GetCarById(int id);
        bool CreateCar(Car car);
        bool UpdateCar(Car car);
        bool DeleteCar(int id);

}