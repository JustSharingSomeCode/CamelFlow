using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamelFlow_Backend.Data.Models
{
    public class WorkflowVersion
    {
        [Key]
        public Guid Id { get; set; }

        public int Version { get; set; }
        public bool IsPublished { get; set; }

        public string Fields { get; set; } = string.Empty;

        public Guid WorkflowId { get; set; }

        [ForeignKey(nameof(WorkflowId))]
        public virtual Workflow? Workflow { get; set; }
    }
}
