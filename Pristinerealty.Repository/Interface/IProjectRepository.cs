using Pristinerealty.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pristinerealty.Repository.Interface
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjects();
        Task<Project> GetById(int id);
        Task<int> Add(Project project);
        Task<int> Delete(int id);
    }
}
