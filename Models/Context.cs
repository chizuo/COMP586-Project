using Microsoft.EntityFrameworkCore;
using Registration.DbModels;
namespace Registration.Models
{
    public class Context : DbContext
    {
        public DbSet<Login> login { get; set; }
        public DbSet<dbCourse> dbCourses { get; set; }
        public DbSet<dbDepartment> dbDepartments { get; set; }
        public DbSet<dbPreReq> dbPreReqs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=Data/Registration.db");
    }
}