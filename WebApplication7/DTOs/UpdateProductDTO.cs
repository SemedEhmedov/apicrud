namespace WebApplication7.DTOs
{
    public record UpdateProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int count { get; set; }
        public int CategoryId { get; set; }
    }
}
