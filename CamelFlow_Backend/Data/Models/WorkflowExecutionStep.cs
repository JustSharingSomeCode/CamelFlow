using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamelFlow_Backend.Data.Models
{
    public class WorkflowExecutionStep
    {
        [Key]
        public Guid Id { get; set; }

        public Guid StepId { get; set; } //How to link with step on table WorkflowVersion?

        public string Answers { get; set; } = string.Empty;

        public Guid WorkflowExecutionId { get; set; }

        [ForeignKey(nameof(WorkflowExecutionId))]
        public virtual WorkflowExecution? WorkflowExecution { get; set; }
    }
}
