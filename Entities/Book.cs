using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCatalog.API.Entities
{
    public class Book : Product
    {
        private string _author;
        private long _pages;

        public Book() { }

        public Book(string name, string description, decimal price, long quantity, string type, string author, long pages) 
            : base(name, description, price, quantity, type)
        {
            Author = author;
            Pages = pages;
        }

        [Required]
        [Column("Author", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Author
        {
            get { return _author; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 1)
                {
                    throw new ArgumentException("O nome do altor deve ter mais de um caractere.");
                }
             _author = value;
            }
        }

        [Required]
        [Column("Pages", TypeName = "bigint")]
        public long Pages
        {
            get { return _pages; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("O livro deve possuir páginas.");
                }
            }
            
        }
    }
}
