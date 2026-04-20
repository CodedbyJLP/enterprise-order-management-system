using MongoDB.Bson;

namespace ProductService.Domain.Entities
{
    public class ProductImages
    {
        public ObjectId Id { get; set; }
        public ObjectId ProductId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
