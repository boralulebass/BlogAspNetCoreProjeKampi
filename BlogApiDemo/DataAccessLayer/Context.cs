using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-D0HPTG1\\SQLEXPRESS;database=DbCoreBlogAPI; integrated security=true;");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
