using ProductCatalog.API.Entities.Customers;
using ProductCatalog.API.Model.Context;
using ProductCatalog.API.Services.Interfaces;

namespace ProductCatalog.API.Services.Implementation
{
    public class CustomerServices : ICustomerServices
    {
        private readonly MSSQLContext _context;

        public CustomerServices(MSSQLContext context)
        {
            this._context = context;
        }

        public Customer Create(Customer customer)
        {

            var emailExisating = _context.Customer.Any(e => e.Email == customer.Email);

            if(emailExisating)
            {
                throw new ArgumentException("Já existe um cliente com esse email.");
            }

            _context.Customer.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public List<Customer> FindAll()
        {
            return _context.Customer.ToList();
        }

        public Customer FindById(long id)
        {
            return _context.Customer.FirstOrDefault(p => p.Id == id);
        }

        public Customer? Updade(Customer customer)
        {
            var existing = FindById(customer.Id);

            if (existing == null)
                return null;

            existing.Name = customer.Name;
            existing.Email = customer.Email;
            existing.Phone = customer.Phone;
            existing.BirthDate = customer.BirthDate;
            existing.Password = customer.Password;
            _context.SaveChanges();

            return existing;
        }

        public bool Delete (long id)
        {
            var customer = FindById(id);
            if (customer == null) return false;

            _context.Customer.Remove(customer);
            _context.SaveChanges();

            return true;
        }

  
    
    }
}
