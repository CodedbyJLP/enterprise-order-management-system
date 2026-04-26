using MongoDB.Bson;

namespace ProductService.Domain.Entities
{
    public class ProductsDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryId { get; set; }
        public string Currency { get; set; }
        public bool IsActive { get; set; }

        public string[] Tags { get; set; }
        public string ImageUrl { get; set; }

        public List<ProductAttributes> Attributes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Nullable<DateTime> UpdatedAt { get; set; }

        public Nullable<bool> IsAvailable { get; set; }
    }

   
}


