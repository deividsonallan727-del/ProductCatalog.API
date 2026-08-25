using ProductCatalog.API.Entities.Customers;

namespace ProductCatalog.API.Services.Interfaces
{
    public interface ICustomerServices
    {
        Customer Create(Customer customer);
        Customer FindById(long  id);
        List<Customer> FindAll();
        Customer? Updade (Customer customer);
        bool Delete(long  id);
    }
}
