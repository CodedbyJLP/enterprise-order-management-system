using MongoDB.Bson;

namespace ProductService.Domain.Entities
{
    public class CategoryEntity
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime? UpdatedAt { get; set; }

    }
}
