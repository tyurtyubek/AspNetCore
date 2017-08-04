using AspNetCoreApp.Context;
using AspNetCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreApp.Services
{
    public class JobService : IJobService
    {
        private JobContext _data;

        public JobService(JobContext context)
        {
            _data = context;

        }

        public async Task AddAsync(Worker worker)
        {
            await _data.Workers.AddAsync(worker);
            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Worker item = await _data.Workers.FindAsync(id);
            if (item != null)
                _data.Workers.Remove(item);
            await SaveAsync();
        }

        public async Task EditAsync(Worker worker)
        {
            _data.Entry(worker).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task<List<Worker>> GetAllAsync()
        {
            return await _data.Workers.ToListAsync();
        }

        public async Task<Worker> GetByIdAsync(int id)
        {
            return await _data.Workers.FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _data.SaveChangesAsync();
        }

        private bool dispose = false;

        public virtual void Dispose(bool disposing)
        {
            if (!dispose)
            {
                if (disposing)
                {
                   _data.Dispose();
                }
            }
            dispose = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
