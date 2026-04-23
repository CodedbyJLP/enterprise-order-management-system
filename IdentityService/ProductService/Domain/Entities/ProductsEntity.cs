using MongoDB.Bson;

namespace ProductService.Domain.Entities
{
    public class ProductsEntity
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ObjectId CategoryId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Nullable<DateTime> UpdatedAt { get; set; }
        public List<ProductAttributes> Attributes { get; set; }
        public string[] Tags { get; set; }
        public string ImageUrl { get; set; }
    }
    public class ProductAttributes
    {

        public string key { get; set; }
        public string value { get; set; }

    }


}
