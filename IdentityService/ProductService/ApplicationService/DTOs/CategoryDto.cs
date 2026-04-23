namespace ProductService.Domain.Entities
{
    public class CategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }


    }
}
