using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;
using WebAPI.Request;
using WebAPI.Request.Interface;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : Controller
    {
        private readonly ILogger _logger;
        private readonly ITaskRepository _taskRepository;

        public TasksController(ILogger logger, ITaskRepository taskRepository)
        {
            _logger = logger;
            _taskRepository = taskRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<TaskModel>> GetAll()
        {
            _logger.LogInformation("Retrieving all projects");
            try
            {
                var project = _taskRepository.GetAll();
                if (!project.Any())
                {
                    return Ok("No Projects Exists");
                }
                return Ok(project);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving projects");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TaskModel> Get(int id)
        {
            var project = _taskRepository.Get(id);
            if (project == null)
            {
                return NotFound($"No Project Exist with id : {id}");
            }
            return Ok(project);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put(int id, [FromBody] TaskModel task)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (task == null || task.Id != id)
            {
                return NotFound("Cannot Update the Project Details");
            }

            _taskRepository.Update(task);
            return Ok("Updated");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] TaskEditModel task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (task == null)
            {
                return BadRequest("Project Cannot Created");
            }

            _taskRepository.Create(task);
            return Ok("Project Created");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            if (!_taskRepository.TaskExists(id))
            {
                return NotFound($"No Projects Exist with id : {id}");
            }

            _taskRepository.Delete(id);
            return Ok("Project Deleted SuccessFully");
        }
    }
}
