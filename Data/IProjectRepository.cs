using Eytec.API.Model;

namespace Eytec.API.Data
{
    public interface IProjectRepository
    {
        public IEnumerable<ProjectModel> GetAll();
        public ProjectModel Get(int Id);
        public void Update(ProjectModel project);
        public void Create(ProjectModel project);
        public void Delete(int id);
    }
}