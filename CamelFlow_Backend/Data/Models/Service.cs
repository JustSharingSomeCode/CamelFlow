using System.ComponentModel.DataAnnotations;

namespace CamelFlow_Backend.Data.Models
{
    public class Service
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
