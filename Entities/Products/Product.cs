using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCatalog.API.Entities.Products
{

    [Table("Products")]

    public class Product
    {
       
        private long _id;
        private string _name;
        private string _description;
        private decimal _price;
        private long _quantity;

        public Product() { }

        public Product(string name, string description, decimal price, long quantity)
        {

            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        [Key]//chave pprimaria do db primarekey
        [Column("Id")]//coluda id
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//para ser autoIncrementada
        public long Id
        {
            get => _id;
            set => _id = value;
        }

        [Required]
        [Column ("Name", TypeName = "varchar(100)")]
        [MaxLength (100)]
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length <= 1)
                    throw new ArgumentException("O nome deve ter mais de um caractere.");
                _name = value;
            }
        }

        [Required]
        [Column("Description", TypeName = "varchar(500)")]
        [MaxLength(500)]//Maxlength e apenas para texto
        public string Description
        {
            get => _description;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length <= 1)
                    throw new ArgumentException("A descrição deve conter mais de um caractere.");
                _description = value;
            }
        }

        [Required]
        [Column("Price", TypeName = "decimal(10,2)")]//10 → quantidade total de dígitos permitidos. 2 → quantidade de casas decimais. ex: 99999999.99
        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Price), "O preco nao pode ser negativo.");
                _price = value;
            }
        }

        [Required]
        [Column("Quantity", TypeName = "bigint")]
        public long Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Quantity), "A quantidade não pode ser negativa.");
                _quantity = value;
            }
        }

        [NotMapped]
        public string Type => GetType().Name;
       
        public override bool Equals(object? obj)
        {
            return obj is Product product &&
                   _id == product._id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_id);
        }
    }

}
