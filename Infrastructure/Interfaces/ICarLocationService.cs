namespace Infrastructure.Interfaces;
using Domain.Models;

    public interface ICarLocationService
    {
        List<CarLocation> GetAll();
 		CarLocation GetCarLocationById(int id);
        bool CreateCarLocation(CarLocation carLocation);
        bool UpdateCarLocation(CarLocation carLocation);
        bool DeleteCarLocation(int carId, int id);
    }