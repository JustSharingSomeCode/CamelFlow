using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamelFlow_Backend.Data.Models
{
    public class ServiceVersion
    {
        [Key]
        public Guid Id { get; set; }

        public string Fields { get; set; } = string.Empty;

        [Column(TypeName = "money")]
        public decimal PricePerExecution { get; set; }

        public Guid ServiceId { get; set; }

        [ForeignKey(nameof(ServiceId))]
        public virtual Service? Service { get; set; }
    }
}
