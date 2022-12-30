using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;
using WebAPI.Request.Interface;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<TaskModel>> GetAll()
        {
            return Ok(_taskRepository.GetAll());
        }
    }
}
