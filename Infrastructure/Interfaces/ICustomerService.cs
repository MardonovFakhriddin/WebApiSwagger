using Infrastructure.ApiResponse;

namespace Infrastructure.Interfaces;
using Domain.Models;

public interface ICustomerService
{
    Response<List<Customer>> GetAll();
	Response<Customer> GetCustomerById(int id);
    Response<bool> CreateCustomer(Customer customer);
    Response<bool> UpdateCustomer(Customer customer);
    Response<bool> DeleteCustomer(int id);
}