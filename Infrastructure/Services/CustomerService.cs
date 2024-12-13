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

    public List<Customer> GetAll()
    {
        using var context = _context.Connection();
        string cmd = "SELECT * FROM Customers";
        var customers = context.Query<Customer>(cmd).ToList();
        return customers;
    }

    public Customer GetCustomerById(int id)
    {
        using var context = _context.Connection();
        string cmd = "SELECT * FROM Customers WHERE CustomerId = @CustomerId";
        var customer = context.QueryFirstOrDefault<Customer>(cmd, new { CustomerId = id });
        return customer;
    }

    public bool CreateCustomer(Customer customer)
    {
        using var context = _context.Connection();
        var cmd = "INSERT INTO Customers (FullName, Phone, Email) VALUES (@FullName, @Phone, @Email)";
        var response = context.Execute(cmd, customer);
        return response > 0;
    }

    public bool UpdateCustomer(Customer customer)
    {
        using var context = _context.Connection();
        var cmd = "UPDATE Customers SET FullName = @FullName, Phone = @Phone, Email = @Email WHERE CustomerId = @CustomerId";
        var response = context.Execute(cmd, customer);
        return response > 0;
    }

    public bool DeleteCustomer(int id)
    {
        using var context = _context.Connection();
        var cmd = "DELETE FROM Customers WHERE CustomerId = @CustomerId";
        var response = context.Execute(cmd, new { CustomerId = id });
        return response != 0;
    }
}
