using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [DisplayName("No of Tasks")]
        public int NoOfTasks { get; set; }
        [ForeignKey("Status")]
        public int StatusID { get; set; }
        public virtual ProjectStatus Status { get; set; }
    }

    public class ProjectEditModel
    {
        public ProjectModel Project { get; set; }
    }
}