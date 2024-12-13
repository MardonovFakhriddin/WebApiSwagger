using Infrastructure.ApiResponse;

namespace Infrastructure.Interfaces;
using Domain.Models;
public interface ICarService
{
        Response<List<Car>> GetAll();
        Response<Car> GetCarById(int id);
        Response<bool> CreateCar(Car car);
        Response<bool> UpdateCar(Car car);
        Response<bool> DeleteCar(int id);

}