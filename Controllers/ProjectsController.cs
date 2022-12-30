using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;
using WebAPI.Request.Interface;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : Controller
    {
        private readonly ILogger<ProjectsController> _logger;
        private readonly IProjectRepository _projectRepository;

        public ProjectsController(ILogger<ProjectsController> logger, IProjectRepository projectRepository)
        {
            _logger = logger;
            _projectRepository = projectRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProjectModel>> GetAll()
        {
            _logger.LogInformation("Retrieving all projects");
            try
            {
                var project = _projectRepository.GetAll();
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
        public ActionResult<ProjectModel> Get(int id)
        {
            var project = _projectRepository.Get(id);
            if (project == null)
            {
                return NotFound($"No Project Exist with id : {id}");
            }
            return Ok(project);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put(int id, [FromBody] ProjectModel project)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (project == null || project.Id != id)
            {
                return NotFound("Cannot Update the Project Details");
            }

            _projectRepository.Update(project);
            return Ok("Updated");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] ProjectEditModel project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (project == null)
            {
                return BadRequest("Project Cannot Created");
            }

            _projectRepository.Create(project);
            return Ok(CreatedAtAction(nameof(Get), new { id = project.Project.Id }, project));
            return Ok("Project Created");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            if (!_projectRepository.ProjectExists(id))
            {
                return NotFound($"No Projects Exist with id : {id}");
            }

            _projectRepository.Delete(id);
            return Ok("Project Deleted SuccessFully");
        }
    }
}