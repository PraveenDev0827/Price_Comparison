namespace Price_Comparison.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public List<ProductVendorDto> Vendors { get; set; }
    }

    public class ProductVendorDto
    {
        public string VendorName { get; set; }
        public decimal Price { get; set; }
        public bool Availability { get; set; }
        public double Rating { get; set; }
        public string ProductUrl { get; set; }
    }

    public class  SearchDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }

    public class SearchObjectDto
    {
        public string? ProductName { get; set; }
        public string? Category { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public string? SortField { get; set; } = "name"; // "price", "category", etc.
        public string? SortAscending { get; set; } = "asc"; // "asc" or "desc"
    }
}
