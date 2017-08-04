using AspNetCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreApp.Services
{
    public interface IJobService
    {
        Task<List<Worker>> GetAllAsync();
        Task<Worker> GetByIdAsync(int id);
        Task AddAsync(Worker worker);
        Task DeleteAsync(int id);
        Task EditAsync(Worker worker);
        Task SaveAsync();
    }
}
