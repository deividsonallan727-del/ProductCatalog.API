using Microsoft.EntityFrameworkCore;
using ProductCatalog.API.Entities;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasDiscriminator<string>("ProductType")
                .HasValue<Product>("Product")
                .HasValue<Book>("Book")
                .HasValue<Game>("Game");
        }
    }

   
    }
//essa classe e responsavel por estabelecer conexao da aplicacao usando entityframework com banco de dados.