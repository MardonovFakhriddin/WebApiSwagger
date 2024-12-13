namespace Infrastructure.Interfaces; 
using Domain.Models;

public interface IRentalService
{
    List<Rental> GetAll();
    Rental GetRentalById(int id);
    bool CreateRental(Rental rental);
    bool UpdateRental(Rental rental);
    bool DeleteRental(int id);
}