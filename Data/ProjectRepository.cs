using Eytec.API.Model;

namespace Eytec.API.Data
{
    internal class ProjectRepository : IProjectRepository
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectRepository(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public object? Get(int Id)
        {
            throw new NotImplementedException();
        }

        public object? GetAll()
        {
            throw new NotImplementedException();
        }

        public object Update(ProjectModel project)
        {
            throw new NotImplementedException();
        }
    }
}