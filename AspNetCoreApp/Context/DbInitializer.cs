using AspNetCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreApp.Context
{
    public class DbInitializer
    {
        public static void Initialize(JobContext context)
        {
            context.Database.EnsureCreated();

            // Look for any workers.
            if (context.Workers.Any())
            {
                return;   // DB has been seeded
            }
            var workers = new Worker[]
           {
                new Worker{FirstName="Kostia", Profession = "farmer" , experience = 3, Salary = 20000},
                new Worker{FirstName="Vasya", Profession = "milker" , experience = 10, Salary = 9000},
                new Worker{FirstName="Andriy", Profession = "Tractor driver" , experience = 15, Salary = 12000},
           };
            foreach (Worker worker in workers)
            {
                context.Workers.Add(worker);
            }
            context.SaveChanges();
        }
    }
}
