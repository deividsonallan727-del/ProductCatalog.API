using Microsoft.EntityFrameworkCore;
using ProductCatalog.API.Entities.Carts;
using ProductCatalog.API.Entities.Customers;
using ProductCatalog.API.Entities.Products;

namespace ProductCatalog.API.Model.Context
{
    public class MSSQLContext : DbContext
    {

        public MSSQLContext(DbContextOptions<MSSQLContext> options) 
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasDiscriminator<string>("ProductType")
                .HasValue<Product>("Product")
                .HasValue<Book>("Book")
                .HasValue<Game>("Game");

            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.Product)
                .WithMany()
                .HasForeignKey(c => c.ProductId);
        }
    }

   
    }
//essa classe e responsavel por estabelecer conexao da aplicacao usando entityframework com banco de dados.