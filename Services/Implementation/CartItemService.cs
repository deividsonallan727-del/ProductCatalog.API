using ProductCatalog.API.Entities.Carts;
using ProductCatalog.API.Model.Context;
using ProductCatalog.API.Services.Interfaces;
using ProductCatalog.API.Services.Implementation;
using Microsoft.EntityFrameworkCore;

namespace ProductCatalog.API.Services.Implementation
{
    public class CartItemService : ICartItemServices
    {
        private readonly MSSQLContext _context;

        public CartItemService(MSSQLContext context)
        {
            _context = context;
        }

        public CartItem addItem(long cartId, long productId, long quantity)
        {
            var cart = _context.Carts.Find(cartId);
            if (cart == null)
                throw new Exception("Carrinho não encontrado.");

            var product = _context.Products.Find(productId);

            if (product == null)
                throw new Exception("Produto não encontrado.");

            var cartItem = new CartItem
            {
                CartId = cartId,
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = product.Price
            };

            _context.CartItems.Add(cartItem);
            _context.SaveChanges();

            return cartItem;

        }
        public List<CartItem> FindByCartId(long cartId)
        {
            return _context.CartItems
                .Include(x => x.Product)
                .Where(x => x.CartId == cartId)
                .ToList();

        }

        public List<CartItem> FindAllCartItems(long cartId)
        {
            return _context.CartItems
        .Where(x => x.CartId == cartId)
        .ToList();
        }

        public CartItem FindById(long id)
        {
            return _context.CartItems.Include(x => x.Product)
                .FirstOrDefault(p => p.Id == id);
        }

        public CartItem updateQuantity(long id, long quantity)
        {
            var cartItem = _context.CartItems.Find(id);

            if (cartItem == null) return null;

            cartItem.Quantity = quantity;

            _context.SaveChanges();

            return cartItem;
        }

        public bool DeleteCartItem(long id)
        {
            var cartIterm = FindById(id);

            if (cartIterm == null) return false;

            _context.CartItems.Remove(cartIterm);
            _context.SaveChanges();

            return false;
        }

       
    }
}
