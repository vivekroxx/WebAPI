using Eytec.API.Model;

namespace Eytec.API.Data
{
    public interface IProjectRepository
    {
        void Delete(int id);
        object? GetAll();
        object? Get(int Id);
        object Update(ProjectModel project);
    }
}