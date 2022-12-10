using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Registration.Models;
using Registration.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Registration.Controllers
{
    public class SectionController : Controller
    {

        public ActionResult sectionsearch(string? departments = null)
        {
            List<Section> sectionsList = new List<Section>();
            using (var db = new Context())
            {
                var departmentRespone = db.dbDepartments.Single(d => d.code == "COMP");
                Department department = new Department(departmentRespone.name, departmentRespone.code, null);

                var sectionRespone = db.dbSections.AsNoTracking().Where(s => s.dept == "COMP");
                foreach (var sections in sectionRespone)
                {
                    var classDaysRespone = db.dbClassDays.AsNoTracking().Where(d => d.sectionNumber == sections.sectionNumber);

                    foreach (var classDays in classDaysRespone)
                    {
                        Console.WriteLine(classDays.class_day);
                    }

                    Console.WriteLine(sections.sectionNumber);
                    var courseRespone = db.dbCourses.AsNoTracking().Where(c => c.course_Id == sections.course_Id);
                    foreach (var courses in courseRespone)
                    {
                        Course courseObject = new Course(department, courses.number, courses.subject, courses.units, courses.description, new HashSet<string>(), new HashSet<string>(), courses.isLab);
                        Section sectionObject = new Section(courseObject, sections.sectionNumber, sections.schoolTerm, sections.schoolYear, sections.enrollmentCap, sections.waitListcap, sections.waitListTotal, new string[] { "M", "W" }, sections.startTime, sections.endTime, sections.classLocation, null, sections.classNote, null, null);
                        sectionsList.Add(sectionObject);
                        Console.WriteLine(courses.subject);
                    }
                }

            }
            return View(sectionsList);
        }
    }
}
