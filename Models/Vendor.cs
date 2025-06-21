using System.ComponentModel.DataAnnotations;

namespace Price_Comparison.Models
{
    public class Vendor
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? WebsiteUrl { get; set; }
    }
}
