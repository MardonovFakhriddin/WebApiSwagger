using System.Net;
using Infrastructure.ApiResponse;

namespace Infrastructure.Services;

using System.Collections.Generic;
using DefaultNamespace;
using Domain.Models;
using Infrastructure.Interfaces;
using Dapper;
public class CustomerService : ICustomerService
{
    private readonly DapperContext _context;

    public CustomerService(DapperContext context)
    {
        _context = context;
    }

    public Response<List<Customer>> GetAll()
    {
        using var context = _context.Connection();
        string cmd = "SELECT * FROM Customers";
        var customers = context.Query<Customer>(cmd).ToList();
        return new Response<List<Customer>>(customers);
    }

    public Response<Customer> GetCustomerById(int id)
    {
        using var context = _context.Connection();
        string cmd = "SELECT * FROM Customers WHERE CustomerId = @CustomerId";
        var customer = context.QueryFirstOrDefault<Customer>(cmd, new { CustomerId = id });
        return customer == null
            ? new Response<Customer>(HttpStatusCode.NotFound, "Customer Not Found")
            : new Response<Customer>(customer);
    }

    public Response<bool> CreateCustomer(Customer customer)
    {
        using var context = _context.Connection();
        var cmd = "INSERT INTO Customers (FullName, Phone, Email) VALUES (@FullName, @Phone, @Email)";
        var response = context.Execute(cmd, customer);
        return response == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.Created, "Customer successfully created");
    }

    public Response<bool> UpdateCustomer(Customer customer)
    {
        using var context = _context.Connection();
        var existingCustomer = GetCustomerById(customer.CustomerId).Data;
        if (existingCustomer == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Customer not found");
        }
        var cmd = "UPDATE Customers SET FullName = @FullName, Phone = @Phone, Email = @Email WHERE CustomerId = @CustomerId";
        var response = context.Execute(cmd, customer);
        return response > 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Response<bool>(HttpStatusCode.OK, "Customer successfully updated");
    }

    public Response<bool> DeleteCustomer(int id)
    {
        using var context = _context.Connection();
        var customer = GetCustomerById(id).Data;
        if (customer == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Customer not found");
        }
        var cmd = "DELETE FROM Customers WHERE CustomerId = @CustomerId";
        var response = context.Execute(cmd, new { CustomerId = id });
        return response > 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal server error")
            : new Response<bool>(HttpStatusCode.OK, "Customer successfully deleted");
    }
}
