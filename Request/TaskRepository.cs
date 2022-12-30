using WebAPI.Model;
using WebAPI.Request.Interface;

namespace WebAPI.Request
{
    public class TaskRepository : ITaskRepository
    {
        public void Create(ProjectEditModel project)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProjectModel Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool ProjectExists(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProjectModel project)
        {
            throw new NotImplementedException();
        }
    }
}
