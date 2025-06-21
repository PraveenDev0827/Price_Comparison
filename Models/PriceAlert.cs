using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Price_Comparison.Models
{
    public class PriceAlert
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Users")]
        public Guid UserId { get; set; }
        [ForeignKey("Products")]
        public Guid ProductId { get; set; }
        public decimal TargetPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsNotified { get; set; }

        public virtual User Users { get; set; }
        public virtual Product Products { get; set; }

    }
}
