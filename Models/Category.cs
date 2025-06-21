using System.ComponentModel.DataAnnotations;

namespace Price_Comparison.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Product> Products { get; set; }
    }
}
