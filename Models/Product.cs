using System.ComponentModel.DataAnnotations.Schema;

namespace Price_Comparison.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [ForeignKey("Categories")]
        public Guid? CategoryId { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public virtual Category? Categories { get; set; }
    }
}
