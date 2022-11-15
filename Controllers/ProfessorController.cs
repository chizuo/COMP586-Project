using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Registration.Models;

namespace Registration.Controllers
{
    public class ProfessorController : Controller
    {
        Dictionary<string, string> db_login = new Dictionary<string, string>() { { "123456789", "Comp#586" } };
        Dictionary<string, Professor> db_users = new Dictionary<string, Professor>();
        Dictionary<string, Course> db_courses = new Dictionary<string, Course>();
        Dictionary<string, Student> db_student = new Dictionary<string, Student>();

        Professor professor = new Professor("Brandon", "Sorto", "Male", 01, 01, 1000, "45800 Challenger Way Spc 127", "Lancaster", "CA", 93535, "Professor", null);
        Student student = new Student("First Name", "Last Name", "Male/Female", 01, 01, 1050, "Street address", "City Name", "State initals", 00000, "Student", null);

        static Course course586 = new Course("Computer Science", 586, "OOP", "Review of object oriented concepts. Comparison with functional methods.", new HashSet<Course>(), new HashSet<Course>());
        static Course course610 = new Course("Computer Science", 610, "DSA", "Data Structures and algorithms", new HashSet<Course>(), new HashSet<Course>());
        static Course course620 = new Course("Computer Science", 620, "Comp Sys Arch", "Computer System Architecture", new HashSet<Course>(), new HashSet<Course>());
        static Course course615 = new Course("Computer Science", 615, "ATC", "Advanced Topics in Computation Theory", new HashSet<Course>(), new HashSet<Course>());

        Section section586 = new Section(course586, 10000, "fall", "2022", 28, new List<Student>(), 15, 0, new string[] { "T" }, 1900, 2145, "JD1618", "Tues", "Department Office: JD 4503; (818) 677-3398. College of Engineering and Computer Science.", new Dictionary<int, bool>(), null);
        Section section610 = new Section(course610, 10001, "fall", "2022", 28, new List<Student>(), 15, 0, new string[] { "Sa" }, 1500, 1745, "JD3508", "Sat", "Department Office: JD 4503; (818) 677-3398. College of Engineering and Computer Science.", new Dictionary<int, bool>(), null);
        Section section620 = new Section(course620, 10002, "fall", "2022", 28, new List<Student>(), 15, 0, new string[] { "Th" }, 1500, 1745, "JD1105", "Thurs", "Department Office: JD 4503; (818) 677-3398. College of Engineering and Computer Science.", new Dictionary<int, bool>(), null);
        Section section615 = new Section(course615, 10003, "fall", "2022", 28, new List<Student>(), 15, 0, new string[] { "M" }, 1900, 2145, "JD6617", "Mon", "Department Office: JD 4503; (818) 677-3398. College of Engineering and Computer Science.", new Dictionary<int, bool>(), null);



        // GET: /Professor/
        public ActionResult index()
        {
            ViewData["message"] = "";
            return View();
        }

        public ActionResult dashboard(User user)
        {
            if (db_login.ContainsKey(user.id) && user.password == db_login[user.id])
            {
                db_users.Add("123456789", professor);
                db_student.Add("987654321", student);

                db_courses.Add("586", course586);
                db_courses.Add("610", course610);
                db_courses.Add("620", course620);
                db_courses.Add("615", course615);

                section586.addProfessor(professor, section586);
                section610.addProfessor(professor, section610);
                section620.addProfessor(professor, section620);
                section615.addProfessor(professor, section615);

                return View("Dashboard");
            }
            else
            {
                ViewData["message"] = "The credentials you entered are incorrect";
                return View("Index");
            }
        }
    }
}