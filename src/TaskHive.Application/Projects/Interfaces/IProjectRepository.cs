using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskHive.Application.Interfaces.Repositories
{
    public interface IProjectRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetProjectsAsync();
        Task<T> GetProjectAsync(Guid id);
    }
}