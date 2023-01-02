using WebAPI.Model;

namespace WebAPI.Request.Interface
{
    public interface ITaskRepository
    {
        public IEnumerable<TaskModel> GetAll();
        public TaskModel Get(int Id);
        public void Update(TaskModel task);
        public void Create(TaskEditModel task);
        public void Delete(int id);
        bool TaskExists(int id);
    }
}
