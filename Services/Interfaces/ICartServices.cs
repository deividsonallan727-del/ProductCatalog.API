using ProductCatalog.API.Entities.Carts;


namespace ProductCatalog.API.Services.Interfaces
{
    public interface ICartServices
    {
        public Cart Create(long id);
        List<Cart> FindAll();
        Cart FindByCustomerId(long customerId);
        Cart FindById(long id);
        bool Delete (long id);
    }
}