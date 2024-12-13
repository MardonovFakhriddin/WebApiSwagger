using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class LocationController(ILocationService locationService) : ControllerBase
{
    [HttpGet]
    public List<Location> GetAll()
    {
        var response = locationService.GetAll();
        return response;
    }

    [HttpPost]
    public bool CreateLocation(Location location)
    {
        var response = locationService.CreateLocation(location);
        return response;
    }

    [HttpPut]
    public bool UpdateLocation(Location location)
    {
        var response = locationService.UpdateLocation(location);
        return response;
    }

    [HttpDelete]
    public bool DeleteLocation(int id)
    {
        var response = locationService.DeleteLocation(id);
        return response;
    }
}