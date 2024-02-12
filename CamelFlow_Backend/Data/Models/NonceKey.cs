using System.ComponentModel.DataAnnotations;

namespace CamelFlow_Backend.Data.Models
{
    public class NonceKey
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime ExpiresAt { get; set; }
    }
}
