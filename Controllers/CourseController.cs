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

        public ActionResult index(string? course = "COMP380")
        {
            using (var db = new Context())
            {
                var courseRespone = db.dbCourses.Single(c => c.course_Id == course);
                var deptRespone = db.dbDepartments.Single(d => d.code == courseRespone.department);
                var preRespone = db.dbPreReqs.AsNoTracking().Where(pre => pre.course_Id == course);
                var coRespone = db.dbCoReqs.AsNoTracking().Where(core => core.course_Id == course);

                Department Comp = new Department(deptRespone.name, deptRespone.code, null);
                Course courseObject = new Course(Comp, courseRespone.number, courseRespone.subject, courseRespone.units, courseRespone.description, new HashSet<string>(), new HashSet<string>(), courseRespone.isLab);

                foreach (var preReq in preRespone)
                {
                    var prerequisites = db.dbCourses.AsNoTracking().Where(pre => pre.course_Id == preReq.prereq_Id);
                    foreach (var preCourse in prerequisites)
                    {
                        Console.WriteLine(preCourse.course_Id);
                        pre.Add(preCourse.course_Id);
                    }
                }
                courseObject.PreRequisites = pre;

                foreach (var coReq in coRespone)
                {
                    var corequisites = db.dbCourses.AsNoTracking().Where(co => co.course_Id == coReq.coreq_Id);
                    foreach (var coCourse in corequisites)
                    {
                        Console.WriteLine(coCourse.course_Id);
                        co.Add(coCourse.course_Id);
                    }
                }
                courseObject.CoRequisites = co;

                return View(courseObject);
            }

        }

        public ActionResult qualify(int? studentid = 1234, string? courseid = "COMP610")
        {
            using (var db = new Context())
            {

                var courseRespone = db.dbCourses.Single(c => c.course_Id == courseid);
                var preRespone = db.dbPreReqs.AsNoTracking().Where(pre => pre.course_Id == courseid);
                var coRespone = db.dbCoReqs.AsNoTracking().Where(core => core.course_Id == courseid);

                var deptRespone = db.dbDepartments.Single(d => d.code == courseRespone.department);
                Department Comp = new Department(deptRespone.name, deptRespone.code, null);

                Course course = new Course(Comp, courseRespone.number, courseRespone.subject, courseRespone.units, courseRespone.description, new HashSet<string>(), new HashSet<string>(), courseRespone.isLab);

                foreach (var preReq in preRespone)
                {
                    var prerequisites = db.dbCourses.AsNoTracking().Where(pre => pre.course_Id == preReq.prereq_Id);
                    foreach (var preCourse in prerequisites)
                    {
                        pre.Add(preCourse.course_Id);
                    }
                }
                course.PreRequisites = pre;

                foreach (var coReq in coRespone)
                {
                    var corequisites = db.dbCourses.AsNoTracking().Where(co => co.course_Id == coReq.coreq_Id);
                    foreach (var coCourse in corequisites)
                    {
                        co.Add(coCourse.course_Id);
                    }
                }
                course.CoRequisites = co;

                var sectionRespone = db.dbSections.Single(s => s.sectionNumber == 10007);
                var gradeRespone = db.dbStudents.Single(g => g.student_id == studentid.ToString());
                var courseRes = db.dbCourses.Single(c => c.course_Id == gradeRespone.course_id);

                Course courseobject = new Course(Comp, courseRes.number, courseRes.subject, courseRes.units, courseRes.description, new HashSet<string>(), new HashSet<string>(), courseRes.isLab);

                //Section section = new Section(course, sectionRespone.sectionNumber, sectionRespone.schoolTerm, sectionRespone.schoolYear, sectionRespone.enrollmentCap, sectionRespone.waitListcap, sectionRespone.waitListTotal, null, sectionRespone.startTime, sectionRespone.endTime, sectionRespone.classLocation, null, sectionRespone.classNote, null, null);
                Console.WriteLine("Course Name - " + gradeRespone.course_id);

                List<Tuple<Course, double>> trans = new List<Tuple<Course, double>>();
                trans.Add(Tuple.Create(courseobject, (double)gradeRespone.grade));

                var personRespone = db.dbPerson.Single(s => s.id == studentid);

                Student student = new Student(personRespone.id, personRespone.first, personRespone.last, personRespone.Gender, personRespone.birthMonth, personRespone.birthDay, personRespone.birthYear,
                                                        personRespone.address, personRespone.city, personRespone.state, personRespone.zip, personRespone.personType, trans, null,
                                                        personRespone.middle, personRespone.email, personRespone.areaCode, personRespone.phone, null);


                //student.Transcript.Add(Tuple.Create(section, (double)gradeRespone.grade))

                Console.WriteLine(course.requirements(student));
            }

            return View();
        }
    }
}