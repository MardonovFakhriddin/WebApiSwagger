using Infrastructure.ApiResponse;

namespace Infrastructure.Interfaces;
using Domain.Models;

    public interface ICarLocationService
    {
        Response<List<CarLocation>> GetAll();
 		Response<CarLocation> GetCarLocationById(int id);
        Response<bool> CreateCarLocation(CarLocation carLocation);
        Response<bool> UpdateCarLocation(CarLocation carLocation);
        Response<bool> DeleteCarLocation(int carId, int id);
    }