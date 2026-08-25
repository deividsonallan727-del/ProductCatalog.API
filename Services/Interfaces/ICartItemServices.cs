using ProductCatalog.API.Entities.Carts;
namespace ProductCatalog.API.Services.Interfaces
{
    public interface ICartItemServices
    {
      public  CartItem addItem(long cartId, long productId, long quantity);
        /*
         cartId    → long → identifica o carrinho
         productId → long → identifica o produto
         quantity  → int  → quantidade de unidades
         */
        public List<CartItem> FindByCartId(long cartId);
        public List<CartItem> FindAllCartItems(long cartId);
       public CartItem FindById(long id);
       public CartItem updateQuantity(long id, long quantity);
       public bool DeleteCartItem (long id);
    }
}
