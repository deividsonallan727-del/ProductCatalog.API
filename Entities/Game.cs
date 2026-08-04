using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace ProductCatalog.API.Entities
{
    public class Game : Product
    {
        private string _platform;
        private string _genre;

        public Game() { }

        public Game(string name, string description, decimal price, long quantity, string type, string platform, string developer)
            : base(name, description, price, quantity, type)
        {
            Platform = platform;
            Genre = developer;
        }

        [Required]
        [Column("Platform", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Platform
        {
            get { return _platform; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("A plataforma não pode ser vazia.");

                _platform = value;
            }
        }

        [Required]
        [Column("Genre", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Genre
        {
            get { return _genre; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("O desenvolvedor não pode ser vazio.");

                _genre = value;
            }
        }
    }
}
