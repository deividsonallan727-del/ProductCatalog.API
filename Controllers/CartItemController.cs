using ProductCatalog.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace ProductCatalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemServices _cartItemServices;

        public CartItemController (ICartItemServices services)
        {
            _cartItemServices = services;
        }
        [HttpGet("cart/{cartId}")]
        public ActionResult FindByCartId(long cartId)
        {
            return Ok(_cartItemServices.FindByCartId(cartId));
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var cartItem = _cartItemServices.FindById(id);
            if (cartItem == null) return NotFound();

            return Ok(cartItem);

        }

        // Adicionar produto ao carrinho
        [HttpPost]
        public IActionResult Post(long cartId, long productId, int quantity)
        {
            var cartItem = _cartItemServices.addItem(
                cartId,
                productId,
                quantity
            );

            return CreatedAtAction(
                nameof(Get),
                new { id = cartItem.Id },
                cartItem
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, int quantity)
        {
            var cartItem = _cartItemServices.updateQuantity(id, quantity);

            if (cartItem == null)
                return NotFound();

            return Ok(cartItem);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var deleted = _cartItemServices.DeleteCartItem(id);

            if(!deleted) return NotFound();

            return NoContent();
        }
    }
}
