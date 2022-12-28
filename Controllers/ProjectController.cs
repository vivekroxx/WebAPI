using Eytec.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Eytec.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
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
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put(int id, [FromBody] ProjectModel project)
        {
            if (project == null || project.Id != id)
            {
                return BadRequest();
            }

            var updatedProject = _projectRepository.Update(project);
            if (updatedProject == null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            //if (!_projectRepository.Exists(id))
            //{
            //    return NotFound();
            //}

            _projectRepository.Delete(id);
            return NoContent();
        }
    }
}