using Infrastructure.ApiResponse;

namespace Infrastructure.Interfaces;
using Domain.Models;

public interface IRentalService
{
    Response<List<Rental>> GetAll();
    Response<Rental> GetRentalById(int id);
    Response<bool> CreateRental(Rental rental);
    Response<bool> UpdateRental(Rental rental);
    Response<bool> DeleteRental(int id);
}