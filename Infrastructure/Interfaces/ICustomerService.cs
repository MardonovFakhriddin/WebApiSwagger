namespace Infrastructure.Interfaces; 
using Domain.Models;

public interface ICustomerService
{
    List<Customer> GetAll();
	Customer GetCustomerById(int id);
    bool CreateCustomer(Customer customer);
    bool UpdateCustomer(Customer customer);
    bool DeleteCustomer(int id);
}