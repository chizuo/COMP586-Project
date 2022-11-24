using Microsoft.EntityFrameworkCore;
namespace Registration.Models
{
    public class Context : DbContext
    {
        public DbSet<Login> login { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=Data/Registration.db");
    }
}