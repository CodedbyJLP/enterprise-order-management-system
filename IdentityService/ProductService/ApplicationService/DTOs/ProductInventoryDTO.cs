namespace ProductService.Domain.Entities
{
    public class ProductInventoryDTO
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public int Available { get; set; }

        public int Reserved { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
