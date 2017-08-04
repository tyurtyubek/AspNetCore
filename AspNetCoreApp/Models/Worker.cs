using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreApp.Models
{
    public class Worker
    { 
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Profession { get; set; }
        public double Salary { get; set; }
        public int experience { get; set; }
    }
}
