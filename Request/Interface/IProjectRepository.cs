using WebAPI.Model;

namespace WebAPI.Request.Interface
{
    public interface IProjectRepository
    {
        public IEnumerable<ProjectModel> GetAll();
        public ProjectModel Get(int Id);
        public void Update(ProjectModel project);
        public void Create(ProjectEditModel project);
        public void Delete(int id);
        public bool ProjectExists(int id);

    }
}