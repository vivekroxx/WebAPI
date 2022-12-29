namespace Eytec.API.Model
{
    public class ProjectModel : ProjectEditModel
    {
        public int Id { get; set; }
    }

    public class ProjectEditModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NoOfTasks { get; set; }
        public string? Status { get; set; }
    }
}