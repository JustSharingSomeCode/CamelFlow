using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamelFlow_Backend.Data.Models
{
    public class WorkflowExecution
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime ExecutionStartedDate { get; set; }
        public DateTime ExecutionEndedDate { get; set; }

        public Guid WorkflowVersionId { get; set; }

        [ForeignKey(nameof(WorkflowVersionId))]
        public virtual WorkflowVersion? WorkflowVersion { get; set; }
    }
}
