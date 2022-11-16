using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Registration.Models;

namespace Registration.Controllers
{
    public class CourseController : Controller
    {
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

        public ActionResult index()
        {
            CourseView course = new CourseView(db_courses["Comp586"].deptName, db_courses["Comp586"].courseNumber, db_courses["Comp586"].courseName, db_courses["Comp586"].units, db_courses["Comp586"].courseDescription);

            return View(course);
        }
    }
}