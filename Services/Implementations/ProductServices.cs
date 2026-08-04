using ProductCatalog.API.Entities;
using ProductCatalog.API.Model.Context;


namespace ProductCatalog.API.Services.Implementations
{
    public class ProductServices : IProductServices
    {
        private readonly MSSQLContext _context;

        public ProductServices(MSSQLContext context)
        {
            this._context = context;
        }
        public Product Create(Product product)
        {
  
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public List<Product> FindAll()
        {
            return _context.Products.ToList();
        }
        public List<Book> FindAllBooks()
        {
            return _context.Books.ToList();
        }
        public List<Game> FindAllGames()
        {
            return _context.Games.ToList();
        }

        public Product? FindById(long id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
        public Book? FindBookById(long id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public Game? FindGameById(long id)
        {
            return _context.Games.FirstOrDefault(g => g.Id == id);
        }

        public Product? Update(Product product)
        {
           var existing = FindById(product.Id);

            if (existing == null)
                return null;

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.Description = product.Description;

            _context.SaveChanges();

            return existing;
        }
        public Book? UpdateBook(Book book)
        {
            var existingBook = _context.Books.FirstOrDefault(b => b.Id == book.Id);

            if (existingBook == null)
                return null;

            existingBook.Pages = book.Pages;
            existingBook.Author = book.Author;

            _context.SaveChanges();

            return existingBook;
        }
        public Game? UpdateGame(Game game)
        {
            var existingGame = _context.Games.FirstOrDefault(g => g.Id == game.Id);

            if (existingGame == null)
                return null;

            existingGame.Platform = game.Platform;
            existingGame.Genre = game.Genre;

            return existingGame;

        }
        public bool Delete(long id)
        {
            var product = FindById(id);

            if (product == null)
                return false;

            _context.Products.Remove(product);
            _context.SaveChanges();

            //remove do banco
            return true;
               
        }
    }
}
//o fluxo fica:
/*
 GET /api/products
        ↓
Controller
        ↓
ProductServices
        ↓
_context.Products.ToList()
        ↓
SQL Server
        ↓
Cyberpunk 2077 + Senhor dos Anéis
 */