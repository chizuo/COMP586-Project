using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Registration.Models;

namespace Registration.Controllers
{
    public class ProfessorController : Controller
    {
        Dictionary<string, string> db_login = new Dictionary<string, string>() { { "123456789", "Comp#586" } };
        static Dictionary<string, Professor> db_professors = new Dictionary<string, Professor>()
        {
            {"123456789", new Professor("Brandon", "Sorto", "Male", 01, 01, 1000, "45800 Challenger Way Spc 127", "Lancaster", "CA", 93535, "Professor", null)}
        };

        static Dictionary<string, Course> db_courses = new Dictionary<string, Course>()
        {
            {"Comp586", new Course("Computer Science", 586, "OOP", "Review of object oriented concepts. Comparison with functional methods.", new HashSet<Course>(), new HashSet<Course>())},
            {"Comp610", new Course("Computer Science", 610, "DSA", "Data Structures and algorithms", new HashSet<Course>(), new HashSet<Course>())},
            {"Comp620", new Course("Computer Science", 620, "DSA", "Data Structures and algorithms", new HashSet<Course>(), new HashSet<Course>())},
            {"Comp615", new Course("Computer Science", 615, "ATC", "Advanced Topics in Computation Theory", new HashSet<Course>(), new HashSet<Course>())},
        };
        static Dictionary<string, Student> db_student = new Dictionary<string, Student>()
        {
            {"987654321", new Student("First Name", "Last Name", "Male/Female", 01, 01, 1050, "Street address", "City Name", "State initals", 00000, "Student", null)}
        };

        static Dictionary<string, Section> db_sections = new Dictionary<string, Section>()
        {
            {"section586", new Section(db_courses["Comp586"], 10000, "fall", "2022", 28, new List<Student>(), 15, 0, new string[] { "T" }, 1900, 2145, "JD1618", "Tues", "Department Office: JD 4503; (818) 677-3398. College of Engineering and Computer Science.", new Dictionary<int, bool>(), db_professors["123456789"])},
            {"section610", new Section(db_courses["Comp610"], 10001, "fall", "2022", 28, new List<Student>(), 15, 0, new string[] { "Sa" }, 1500, 1745, "JD3508", "Sat", "Department Office: JD 4503; (818) 677-3398. College of Engineering and Computer Science.", new Dictionary<int, bool>(), db_professors["123456789"])},
            {"section620", new Section(db_courses["Comp620"], 10002, "fall", "2022", 28, new List<Student>(), 15, 0, new string[] { "Th" }, 1500, 1745, "JD1105", "Thurs", "Department Office: JD 4503; (818) 677-3398. College of Engineering and Computer Science.", new Dictionary<int, bool>(), db_professors["123456789"])},
            {"section615", new Section(db_courses["Comp615"], 10003, "fall", "2022", 28, new List<Student>(), 15, 0, new string[] { "M" }, 1900, 2145, "JD6617", "Mon", "Department Office: JD 4503; (818) 677-3398. College of Engineering and Computer Science.", new Dictionary<int, bool>(), db_professors["123456789"])},
        };

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