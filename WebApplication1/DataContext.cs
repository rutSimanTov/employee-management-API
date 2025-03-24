using Microsoft.EntityFrameworkCore;
using WebApplication1.Properties.Entities;

namespace WebApplication1
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-1ALELID;Database=employeeManagement;User Id=DESKTOP-1ALELID\\מיכל;Trusted_Connection=True;TrustServerCertificate=True");
            //Integrated Security=True;TrustServerCertificate=True
        }

        public DbSet<Employee> Employees {get;set;}
        public DbSet<Profession> Professions {get;set;}

    }
}
