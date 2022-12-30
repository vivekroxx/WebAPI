using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model
{
    public class TaskModel
    {
        public int Id { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public virtual ProjectModel Project { get; set; }
        [DisplayName("Task Name")]
        public string Name { get; set; }
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
        public string TaskWBS { get; set; }
        [DisplayName("Percent Completed")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PercentComplete { get; set; }
        [ForeignKey("Status")]
        public int StatusID { get; set; }
        public virtual TaskStatus Status { get; set; }
    }

    public class TaskEditModel
    {
        public TaskModel Task { get; set; }
    }
}
