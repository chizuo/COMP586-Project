using Microsoft.EntityFrameworkCore;
using Registration.Db_Models;
namespace Registration.Models
{
    public class Context : DbContext
    {
        public DbSet<Login> login { get; set; }
        public DbSet<DbCourse> DbCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=Data/Registration.db");
    }
}