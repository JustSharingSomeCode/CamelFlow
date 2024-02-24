using System.ComponentModel.DataAnnotations;

namespace CamelFlow_Backend.Data.Models
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; } = string.Empty;
    }
}
