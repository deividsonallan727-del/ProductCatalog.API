using Microsoft.AspNetCore.Mvc;
using ProductCatalog.API.Services.Interfaces;

namespace ProductCatalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartServices _cartServices;

        public CartController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_cartServices.FindAll());
        }

        [HttpGet("cart/{cartId}")]
        public IActionResult Get(long id)
        {
            var cart = _cartServices.FindById(id);

            if(cart == null) return NotFound();

            return Ok(cart);
        }


        [HttpGet("customer/{customerId}")]
        public IActionResult GetByCustomerId(long customerId)
        {
            var cart = _cartServices.FindByCustomerId(customerId);

            if (cart == null)
                return NotFound();

            return Ok(cart);
        }

        // Criar carrinho para um cliente
        [HttpPost("{customerId}")]
        public IActionResult Create(long customerId)
        {
            var cart = _cartServices.Create(customerId);

            if (cart == null)
                return NotFound("Customer não encontrado.");

            return CreatedAtAction(
                nameof(Get),
                new { id = cart.Id },
                cart
            );
        }

        // Deletar carrinho
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var deleted = _cartServices.Delete(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }

}
