namespace Eytec.API.Model
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NoOfTasks { get; set; }
        public string? Status { get; set; }
    }
}