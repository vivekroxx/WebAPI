using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Model;
using WebAPI.Request.Interface;

namespace WebAPI.Request
{
    public class TaskRepository : ITaskRepository
    {
        public ApplicationDbContext _db { get; }

        public TaskRepository(ApplicationDbContext context)
        {
            _db = context;
        }
        public TaskModel Get(int id)
        {
            var task = _db.Tasks.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                return null;
            }
            return task;
        }

        public IEnumerable<TaskModel> GetAll()
        {
            var taskList = _db.Tasks.ToList();
            if (!taskList.Any())
            {
                return Enumerable.Empty<TaskModel>();
            }
            return taskList;
        }

        public void Create(TaskEditModel task)
        {
            var newTask = new TaskModel()
            {
                Name = task.Task.Name,
                EndDate= task.Task.EndDate,
                StartDate= task.Task.StartDate,
                StatusID= task.Task.StatusID,
                PercentComplete= task.Task.PercentComplete,
                TaskWBS= task.Task.TaskWBS,
                ProjectId= task.Task.ProjectId,
            };

            _db.Tasks.Add(newTask);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var task = _db.Tasks.Find(id);

            if (task != null)
            {
                _db.Tasks.Remove(task);
                _db.SaveChanges();
            }
        }

        public void Update(TaskModel task)
        {
            var taskTobeUpdated = _db.Projects.Find(task.Id);

            if (taskTobeUpdated != null)
            {
                taskTobeUpdated.Name = task.Name;
                taskTobeUpdated.StartDate = task.StartDate;
                taskTobeUpdated.EndDate = task.EndDate;
                taskTobeUpdated.StatusID = task.StatusID;
            }

            _db.Update(taskTobeUpdated);
            _db.SaveChanges();
        }

        public bool TaskExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
