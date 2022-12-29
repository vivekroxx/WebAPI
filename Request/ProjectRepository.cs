using Eytec.API.Data;
using Eytec.API.Model;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace Eytec.API.Request
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjectRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public IEnumerable<ProjectModel> GetAll()
        {
            var listt = _db.Projects.ToList();
            return listt;
        }

        public ProjectModel Get(int id)
        {
            return _db.Projects.Find(id);
        }

        public void Create(ProjectEditModel project)
        {
            var newProject = new ProjectModel()
            {
                Name = project.Name,
                Code = project.Code,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                NoOfTasks = project.NoOfTasks,
                Status = project.Status
            };

            _db.Projects.Add(newProject);
            _db.SaveChanges();
        }

        public void Update(ProjectModel project)
        {
            var projectTobeUpdated = _db.Projects.Find(project.Id);

            if (projectTobeUpdated != null)
            {
                projectTobeUpdated.Name = project.Name;
                projectTobeUpdated.Code = project.Code;
                projectTobeUpdated.StartDate = project.StartDate;
                projectTobeUpdated.EndDate = project.EndDate;
                projectTobeUpdated.NoOfTasks = project.NoOfTasks;
                projectTobeUpdated.Status = project.Status;
            }

            _db.Entry(project).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var project = _db.Projects.Find(id);

            if (project != null)
            {
                _db.Projects.Remove(project);
                _db.SaveChanges();
            }
        }

        public bool ProjectExists(int id)
        {
            return _db.Projects.Any(p => p.Id == id);
        }
    }
}