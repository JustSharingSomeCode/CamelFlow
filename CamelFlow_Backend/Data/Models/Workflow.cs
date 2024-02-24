using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamelFlow_Backend.Data.Models
{
    public class Workflow
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        public Guid CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company? Company { get; set; }
    }
}
