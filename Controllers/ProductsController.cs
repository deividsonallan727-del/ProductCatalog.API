using Microsoft.AspNetCore.Mvc;
using ProductCatalog.API.Entities;
using ProductCatalog.API.Model.Context;
using ProductCatalog.API.Services;

namespace ProductCatalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private MSSQLContext _context;

        private readonly IProductServices _productServices;
        public ProductsController (IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_productServices.FindAll());//busca todos os dados existentes
        }
        [HttpGet("books")]
        public IActionResult GetBooks()
        {
            return Ok(_productServices.FindAllBooks());
        }

        [HttpGet("games")]
        public IActionResult GetGames()
        {
            return Ok(_productServices.FindAllGames());
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var product = _productServices.FindById(id);
            if(product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost("book")]
        public IActionResult PostBook([FromBody] Book book)
        {
            var createdBook = _productServices.Create(book);
            return CreatedAtAction(nameof(Get), new { id = createdBook.Id }, createdBook);
          
        }

        [HttpPost("game")]
        public IActionResult GetGame([FromBody] Game game)
        {
            var createdGame = _productServices.Create(game);
            return CreatedAtAction(nameof(Get), new {id = createdGame.Id}, createdGame);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, 
            [FromBody] Product product)
        {
            product.Id = id;
            var updateProduct = _productServices.Update(product);
            if(updateProduct == null) return NotFound();
            return Ok(updateProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var deleted = _productServices.Delete(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    

    }
}
