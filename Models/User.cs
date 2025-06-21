using System.ComponentModel.DataAnnotations;

namespace Price_Comparison.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public ICollection<SearchHistory> SearchHistories { get; set; }
        public ICollection<PriceAlert> PriceAlerts { get; set; }
    }
}
