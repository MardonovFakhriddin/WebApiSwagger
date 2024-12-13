namespace Infrastructure.Interfaces; 
using Domain.Models;

public interface ILocationService
{
    List<Location> GetAll();
    Location GetLocationById(int id);
    bool CreateLocation(Location location);
    bool UpdateLocation(Location location);
    bool DeleteLocation(int id);
}