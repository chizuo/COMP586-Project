using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Registration.Models;


namespace Registration.Controllers
{
    public class CourseController : Controller
    {


        static Dictionary<string, Professor> db_professors = new Dictionary<string, Professor>()
        {
            {"123456789", new Professor(123456789, "Brandon", "Sorto", "Male", 01, 01, 1000, "45800 Challenger Way Spc 127",
            "Lancaster", "CA", "93535", "Professor", null, middle:"",email:"brandon.sorto@csun.edu", areaCode:"310", phone:"455-8990")}
        };

        static Department comp = new Department("Computer Science", "COMP", db_professors["123456789"]);

        static Dictionary<string, Course> db_courses = new Dictionary<string, Course>()
        {
            {"COMP380", new Course(comp, 380, "Intro Senior Project", 3,"Concepts and techniques for systems engineering, requirements analysis, design, implementation and testing of large-scale computer systems.", new HashSet<Course>(), new HashSet<Course>())},
            {"COMP381", new Course(comp, 381, "Software Engineer Lab", 3, "Software development lab of 3 hours per week for the group activities associated with COMP 380.",new HashSet<Course>(),new HashSet<Course>())},
            {"COMP565", new Course(comp, 565, "ADV Computer Graphics", 3, "This course will cover the theory, design, implementation, and application of advanced computer graphics environments.",new HashSet<Course>(), new HashSet<Course>())},
            {"COMP584", new Course(comp, 584, "ADV Web Engineer", 3, "A study of the concepts, principles, techniques, and methods of Web engineering.", new HashSet<Course>(), new HashSet<Course>())},
            {"COMP586", new Course(comp, 586, "OO Software DEV", 3, "Review of object oriented concepts. Comparison with functional methods.", new HashSet<Course>(), new HashSet<Course>())},
            {"COMP610", new Course(comp, 610, "Data Strctures + Algorithms", 3,"Topics include: design strategies for data structures and algorithms; theoretical limits to space and time requirements time/space trade offs; open problems in the field", new HashSet<Course>(), new HashSet<Course>())},
            {"COMP620", new Course(comp, 620, "Computer System Architecture", 3,"Analysis and evaluation of individual computers, networks of computers and the programs which support their operation and use.", new HashSet<Course>(), new HashSet<Course>())},
            {"COMP615", new Course(comp, 615, "Advanced Topics in Computation Theory", 3,"Languages and the theory of computation are studied in depth.", new HashSet<Course>(), new HashSet<Course>())},
        };

        static HashSet<Course> pre = new HashSet<Course>();
        static HashSet<Course> co = new HashSet<Course>();

        public ActionResult index(string? course = null)
        {
            using (var db = new Context())
            {
                var courseRespone = db.dbCourses.Where(c => c.number == 380).FirstOrDefault();
                if (courseRespone == null)
                {

                }
                else
                {
                    Console.WriteLine(courseRespone.description);
                }
            }
            pre.Add(db_courses["COMP380"]);
            pre.Add(db_courses["COMP381"]);
            co.Add(db_courses["COMP565"]);
            db_courses["COMP586"].PreRequisites = pre;
            db_courses["COMP586"].CoRequisites = co;
            course = course != null ? course : "COMP586";
            return View(db_courses[course]);
        }
    }
}