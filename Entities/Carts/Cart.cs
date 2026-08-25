using ProductCatalog.API.Entities.Customers;

namespace ProductCatalog.API.Entities.Carts
{
    public class Cart
    {
        
        public long Id { get; set; }

        public long CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
