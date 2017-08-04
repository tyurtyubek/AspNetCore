using AspNetCoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApp.Context
{
    public class JobContext: DbContext
    {
        public DbSet<Worker> Workers { get; set; }


        public JobContext(DbContextOptions<JobContext> options) :
            base(options)
        {
                
        }
    }
}
