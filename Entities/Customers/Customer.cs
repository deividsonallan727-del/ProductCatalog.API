using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCatalog.API.Entities.Customers
{
    public class Customer//cliente
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id {  get; set; }
        private string _name; 
        private string _email;
        private string _phone;
        private DateOnly _birthDate;
        private string _password = string.Empty;

        public Customer() { }
        public Customer(string name, string email, string phone, DateOnly birthDate, string password)
        {
            Name = name;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            Password = password;
        }
        [Required]
        public string Name
        {
            get => _name;
            set
            {
               if(string.IsNullOrWhiteSpace(value) || value.Length < 2 )
                    throw new ArgumentException("Necessario ter mais de um caractere.");
                
                _name = value;
            }
        }
        [Required]
        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                    throw new ArgumentException("Email invalido.");

                _email = value;
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 11)
                    throw new ArgumentException("Necessario ter 11 caractere.");

                _phone = value;
            }
        }
        [Required]
        public DateOnly BirthDate
        {
            get => _birthDate;
            set
            {
                if (value > DateOnly.FromDateTime(DateTime.Today))
                    throw new ArgumentException("A data de nascimento noa pode ser no futuro.");
                _birthDate = value;
            }
        }
        [Required]
        public string Password
        {
            get => _password;
            set
            {
                if(string.IsNullOrEmpty(value) || value.Length <= 5)
                {
                    throw new ArgumentException("Necessario uma senha com mais de 5 caractere.");
                }
                _password = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Customer customer &&
                   Id == customer.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
