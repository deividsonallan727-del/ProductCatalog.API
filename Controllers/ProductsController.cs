using Microsoft.AspNetCore.Mvc;
using ProductCatalog.API.Entities.Products;
using ProductCatalog.API.Model.Context;
using ProductCatalog.API.Services.Interfaces;

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

        /*[HttpPost("book")]
        public IActionResult PostBook([FromBody] Book book)
        {
            var createdBook = _productServices.Create(book);
            return CreatedAtAction(nameof(Get), new { id = createdBook.Id }, createdBook);
          
        }*/
        [HttpPost("book")]
        public IActionResult PostBook([FromBody] Book book)
        {
            Console.WriteLine($"Páginas recebidas: {book.Pages}");

            var createdBook = _productServices.Create(book);

            //Console.WriteLine($"Páginas depois do SaveChanges: {createdBook.}");

            return CreatedAtAction(
                nameof(Get),
                new { id = createdBook.Id },
                createdBook
            );
        }

        [HttpPost("game")]
        public IActionResult GetGame([FromBody] Game game)
        {
            var createdGame = _productServices.Create(game);
            return CreatedAtAction(nameof(Get), new {id = createdGame.Id}, createdGame);
        }

        [HttpPut("book/{id}")]
        public IActionResult Put(long id, [FromBody] Book book)
        {
            book.Id = id;
            var updateBook = _productServices.UpdateBook(book);

            if(updateBook == null) return NotFound();

            return Ok(updateBook);
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
