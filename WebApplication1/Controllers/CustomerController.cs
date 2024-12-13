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
    public bool CreateCustomer(Customer customer)
    {
        var response = customerService.CreateCustomer(customer);
        return response;
    }

    [HttpPut]
    public bool UpdateCustomer(Customer customer)
    {
        var response = customerService.UpdateCustomer(customer);
        return response;
    }

    [HttpDelete]
    public bool DeleteCustomer(int id)
    {
        var response = customerService.DeleteCustomer(id);
        return response;
    }
}