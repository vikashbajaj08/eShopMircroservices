namespace Catalog.Application.Dtos
{
    public record ProductDto
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public decimal UnitPrice { get; set; }

        public string ImageUrl { get; set; } = default!;

        public int CategoryId { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
