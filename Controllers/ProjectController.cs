using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;
using WebAPI.Request;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProjectModel>> GetAll()
        {
            return Ok(_projectRepository.GetAll());
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
                if (project == null || project.Id != id)
                {
                    return NotFound("Cannot Update the Project Details");
                }

                _projectRepository.Update(project);
            }
            return Ok("Updated");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] ProjectEditModel project)
        {
            if (ModelState.IsValid)
            {
                if (project == null)
                {
                    return BadRequest("Project Cannot Created");
                }

                _projectRepository.Create(project);
            }
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