using Microsoft.EntityFrameworkCore;
using ProductCatalog.API.Entities.Carts;
using ProductCatalog.API.Model.Context;
using ProductCatalog.API.Services.Interfaces;

namespace ProductCatalog.API.Services.Implementation
{
    public class CartServices : ICartServices
    {
        private readonly MSSQLContext _context;

        public CartServices(MSSQLContext context)
        {
            _context = context;
        }

        public Cart Create(long customerId)
        {
            var existinCart = FindByCustomerId(customerId);

            if(existinCart != null) return existinCart;
           
            var customer = _context.Customer.Find(customerId);

            if (customer == null) return null;

            var cart = new Cart
            {
                CustomerId = customerId,
            };

            _context.Carts.Add(cart);
            _context.SaveChanges();

            return cart;
        }
        public List<Cart> FindAll()
        {
            return _context.Carts.ToList();
        }

        public Cart FindByCustomerId(long customerId)
        {
            return _context.Carts.FirstOrDefault(c => c.CustomerId == customerId);
        }
        public List<CartItem> FindByCartId(long cartId)
        {
            return _context.CartItems
                .Include(x  => x.Product)
                .Where(x => x.CartId == cartId)
                .ToList();
        }
        public Cart FindById(long id)
        {
            return _context.Carts.FirstOrDefault(p => p.Id == id);
        }

        public bool Delete(long id)
        {
            var cart = FindById(id);

            if (cart == null) return false;

            _context.Carts.Remove(cart);
            _context.SaveChanges();
            return true;
        }
    }
}
/*

       Cart Create(long id);
       Cart FindByCustomerId(long customerId);
       Cart FindById(long id);
       bool Delete (long id);


 */