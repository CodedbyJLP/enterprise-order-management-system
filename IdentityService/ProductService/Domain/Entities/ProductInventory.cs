using MongoDB.Bson;

namespace ProductService.Domain.Entities
{
    public class ProductInventory
    {
        public ObjectId Id { get; set; }
        public ObjectId ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdated { get; set; }
        public int Available { get; internal set; }
        public int Reserved { get; internal set; }
    }
}
