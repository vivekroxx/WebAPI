using Eytec.API.Model;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace Eytec.API.Data
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProjectModel> GetAll()
        {
            return _context.Projects;
        }

        public ProjectModel Get(int id)
        {
            return _context.Projects.Find(id);
        }

        public void Create(ProjectModel project)
        {
            _context.Projects.Add(project);
        }

        public void Update(ProjectModel project)
        {
            _context.Entry(project).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var project = _context.Projects.Find(id);

            if (project != null)
            {
                _context.Projects.Remove(project);
            }
        }

        public bool ProjectExists(int id)
        {
            return _context.Projects.Any(p => p.Id == id);
        }
    }
}