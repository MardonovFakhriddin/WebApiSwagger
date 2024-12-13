using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    [HttpGet]
    public List<Customer> GetAll()
    {
        var response = customerService.GetAll();
        return response;
    }

    [HttpPost]
    public bool CreateCarLocation(Customer customer)
    {
        var response = customerService.CreateCustomer(car);
        return response;
    }

    [HttpPut]
    public bool UpdateCarLocation(CarLocation car)
    {
        var response = customerService.UpdateCarLocation(car);
        return response;
    }

    [HttpDelete]
    public bool DeleteCarLocation(int carId,int id)
    {
        var response = customerService.DeleteCarLocation(carId,id);
        return response;
    }
}