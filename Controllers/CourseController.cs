using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Registration.DbModels;
using Registration.Models;
using Microsoft.EntityFrameworkCore;

namespace Registration.Controllers
{
    public class CourseController : Controller
    {
        static HashSet<string> pre = new HashSet<string>();
        static HashSet<string> co = new HashSet<string>();

        public ActionResult index(string? course = null)
        {
            using (var db = new Context())
            {
                var courseRespone = db.dbCourses.Single(c => c.course_Id == "COMP380");
                var deptRespone = db.dbDepartments.Single(d => d.code == courseRespone.department);
                var preRespone = db.dbPreReqs.AsNoTracking().Where(pre => pre.course_Id == "COMP380");
                var coRespone = db.dbCoReqs.AsNoTracking().Where(core => core.course_Id == "COMP380");

                Department Comp = new Department(deptRespone.name, deptRespone.code, null);
                Course courseObject = new Course(Comp, courseRespone.number, courseRespone.subject, courseRespone.units, courseRespone.description, new HashSet<string>(), new HashSet<string>(), courseRespone.isLab);

                foreach (var preReq in preRespone)
                {
                    var prerequisites = db.dbCourses.AsNoTracking().Where(pre => pre.course_Id == preReq.prereq_Id);
                    foreach (var preCourse in prerequisites)
                    {
                        Console.WriteLine(preCourse.course_Id);
                    }
                }
                courseObject.PreRequisites = pre;

                foreach (var coReq in coRespone)
                {
                    var corequisites = db.dbCourses.AsNoTracking().Where(co => co.course_Id == coReq.coreq_Id);
                    foreach (var coCourse in corequisites)
                    {
                        Console.WriteLine(coCourse.course_Id);
                    }
                }
                courseObject.CoRequisites = co;

                return View(courseObject);
            }

        }

        public ActionResult Qualify(string? studentid, string? courseid)
        {
            using (var db = new Context())
            {
                var courseRespone = db.dbCourses.AsNoTracking().Where(c => c.course_Id == "COMP380");
                var studentRespone = db.dbStudents.AsNoTracking().Where(s => s.student_id == studentid);

                foreach (var courses in courseRespone)
                {
                    Console.WriteLine(courses.subject);
                }

                foreach (var student in studentRespone)
                {
                    Console.WriteLine(student.grade);
                }
            }

            return View();
        }
    }
}