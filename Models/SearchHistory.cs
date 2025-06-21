using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Price_Comparison.Models
{
    public class SearchHistory
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Users")]
        public Guid UserId { get; set; }
        public string Query { get; set; } = null!;
        public DateTime SearchedAt { get; set; }

        public virtual User Users { get; set; }
    }
}
