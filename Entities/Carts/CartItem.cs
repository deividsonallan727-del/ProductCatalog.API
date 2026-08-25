using ProductCatalog.API.Entities.Products;
using System.Text.Json.Serialization;

namespace ProductCatalog.API.Entities.Carts
{
    public class CartItem 
    {
        public long Id { get; set; }
        public long CartId { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long  Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        [JsonIgnore]
        public Cart Cart { get; set; }


    }
}
