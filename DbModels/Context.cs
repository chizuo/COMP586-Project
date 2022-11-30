using Microsoft.EntityFrameworkCore;

namespace Registration.DbModels
{
    public class Context : DbContext
    {
        public DbSet<Login> login { get; set; }
        public DbSet<dbPerson> dbPeople { get; set; }
        public DbSet<dbStudent> dbStudents { get; set; }
        public DbSet<dbSection> dbSections { get; set; }
        public DbSet<dbCourse> dbCourses { get; set; }
        public DbSet<dbDepartment> dbDepartments { get; set; }
        public DbSet<dbPreReq> dbPreReqs { get; set; }
        public DbSet<dbCoreReq> dbCoreReqs { get; set; }
        public DbSet<dbClassDays> dbClassDays { get; set; }
        public DbSet<dbAddnumbers> dbAddNumbers {get; set;}
        public DbSet<dbEnrollmentSchedule> dbEnrollmentSchedules {get; set;}

protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite(@"Data Source=Data/Registration.db");
    }
}