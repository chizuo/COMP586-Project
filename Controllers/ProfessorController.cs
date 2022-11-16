using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Registration.Models;

namespace Registration.Controllers
{
    public class ProfessorController : Controller
    {
        static Dictionary<string, string> db_login = new Dictionary<string, string>() { { "admin", "admin" } };
        static Dictionary<string, Professor> db_professors = new Dictionary<string, Professor>()
        {
            {"123456789", new Professor("Brandon", "Sorto", "Male", 01, 01, 1000, "45800 Challenger Way Spc 127", "Lancaster", "CA", 93535, "Professor", null)}
        };

        public static Dictionary<string, Student> db_student = new Dictionary<string, Student>()
        {
            {"1234", new Student("Richard", "Mason", "Male", 01, 01, 1050, "Street address", "City Name", "State initals", 00000, "Student", null)},
            {"2234", new Student("Kevin", "Pillow", "Male", 01, 01, 1050, "Street address", "City Name", "State initals", 00000, "Student", null)},
            {"3334", new Student("Christina", "McGeorge", "Female", 01, 01, 1050, "Street address", "City Name", "State initals", 00000, "Student", null)},
            {"4444", new Student("Carolina", "McGarity", "Male/Female", 01, 01, 1050, "Street address", "City Name", "State initals", 00000, "Student", null)},
        };

        static Dictionary<string, Course> db_courses = new Dictionary<string, Course>()
        {
            {"Comp380", new Course("Computer Science", 380, "Intro Senior Project", 3,"Concepts and techniques for systems engineering, requirements analysis, design, implementation and testing of large-scale computer systems.", new HashSet<Course>(), new HashSet<Course>())},
            {"Comp381", new Course("Computer Science", 381, "Software Engineer Lab", 3, "Software development lab of 3 hours per week for the group activities associated with COMP 380.",new HashSet<Course>(),new HashSet<Course>())},
            {"Comp565", new Course("Computer Science", 565, "ADV Computer Graphics", 3, "This course will cover the theory, design, implementation, and application of advanced computer graphics environments.",new HashSet<Course>(), new HashSet<Course>())},
            {"Comp584", new Course("Computer Science", 584, "ADV Web Engineer", 3, "A study of the concepts, principles, techniques, and methods of Web engineering.", new HashSet<Course>(), new HashSet<Course>())},
            {"Comp586", new Course("Computer Science", 586, "OO Software DEV", 3, "Review of object oriented concepts. Comparison with functional methods.", new HashSet<Course>(), new HashSet<Course>())},
            {"Comp610", new Course("Computer Science", 610, "Data Strctures + Algorithms", 3,"Topics include: design strategies for data structures and algorithms; theoretical limits to space and time requirements time/space trade offs; open problems in the field", new HashSet<Course>(), new HashSet<Course>())},
            {"Comp620", new Course("Computer Science", 620, "Computer System Architecture", 3,"Analysis and evaluation of individual computers, networks of computers and the programs which support their operation and use.", new HashSet<Course>(), new HashSet<Course>())},
            {"Comp615", new Course("Computer Science", 615, "Advanced Topics in Computation Theory", 3,"Languages and the theory of computation are studied in depth.", new HashSet<Course>(), new HashSet<Course>())},
        };

        static Dictionary<string, Section> db_sections = new Dictionary<string, Section>()
        {
            {"section380", new Section(db_courses["Comp380"], 10000, "fall", "2022", 28, new List<Student>(){db_student["1234"]}, 15, 0, new string[] {"M","W"}, 1900, 2145, "JD1618", "M,W", "Department Office: JD 4503; (818) 677-3398. College of Engineering and Computer Science.", new Dictionary<int, bool>(), db_professors["123456789"])},
            {"section381", new Section(db_courses["Comp381"], 10001, "fall", "2022", 28, new List<Student>(){db_student["1234"]}, 15, 0, new string[] {"T","Th"}, 1900, 2145, "JD1618", "T,Th", "Department Office: JD 4503; (818) 677-3398. College of Engineering and Computer Science.", new Dictionary<int, bool>(), db_professors["123456789"])},
            {"section565", new Section(db_courses["Comp565"], 10002, "fall", "2022", 28, new List<Student>(){db_student["2234"], db_student["3334"]}, 15, 0, new string[] {"M","W"}, 1900, 2145, "JD1618", "M,W", "Department Office: JD 4503; (818) 677-3398. College of Engineering and Computer Science.", new Dictionary<int, bool>(), db_professors["123456789"])},
            {"section584", new Section(db_courses["Comp586"], 10003, "fall", "2022", 28, new List<Student>(){db_student["2234"], db_student["3334"]}, 15, 0, new string[] {"T","Th"}, 1900, 2145, "JD1618", "T,Th", "Department Office: JD 4503; (818) 677-3398. College of Engineering and Computer Science.", new Dictionary<int, bool>(), db_professors["123456789"])},
            {"section586", new Section(db_courses["Comp586"], 10004, "fall", "2022", 28, new List<Student>(){db_student["3334"], db_student["2234"]}, 15, 0, new string[] { "T" }, 1900, 2145, "JD1618", "T", "Department Office: JD 4503; (818) 677-3398. College of Engineering and Computer Science.", new Dictionary<int, bool>(), db_professors["123456789"])},
            {"section610", new Section(db_courses["Comp610"], 10005, "fall", "2022", 28, new List<Student>(){db_student["4444"]}, 15, 0, new string[] { "Sa" }, 1500, 1745, "JD3508", "Sa", "Department Office: JD 4503; (818) 677-3398. College of Engineering and Computer Science.", new Dictionary<int, bool>(), db_professors["123456789"])},
            {"section620", new Section(db_courses["Comp620"], 10006, "fall", "2022", 28, new List<Student>(){db_student["4444"]}, 15, 0, new string[] { "Th" }, 1500, 1745, "JD1105", "Th", "Department Office: JD 4503; (818) 677-3398. College of Engineering and Computer Science.", new Dictionary<int, bool>(), db_professors["123456789"])},
            {"section615", new Section(db_courses["Comp615"], 10007, "fall", "2022", 28, new List<Student>(){db_student["4444"]}, 15, 0, new string[] { "M" }, 1900, 2145, "JD6617", "M", "Department Office: JD 4503; (818) 677-3398. College of Engineering and Computer Science.", new Dictionary<int, bool>(), db_professors["123456789"])},
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