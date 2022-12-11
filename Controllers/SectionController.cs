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
                    var personRespone = db.dbPerson.Single(p => p.id == sections.professor);
                    Professor? professor = new Professor(personRespone.id, personRespone.first, personRespone.last, personRespone.Gender, personRespone.birthMonth, personRespone.birthDay, personRespone.birthYear,
                                                        personRespone.address, personRespone.city, personRespone.state, personRespone.zip, personRespone.personType, null,
                                                        personRespone.middle, personRespone.email, personRespone.areaCode, personRespone.phone);

                    var classDaysRespone = db.dbClassDays.AsNoTracking().Where(d => d.sectionNumber == sections.sectionNumber).ToArray();
                    string[] classdays = new string[classDaysRespone.Length];
                    for (int i = 0; i < classDaysRespone.Length; i++)
                    {
                        classdays[i] = classDaysRespone[i].class_day;
                    }
                    
                    Console.WriteLine(sections.sectionNumber);
                    var courseRespone = db.dbCourses.AsNoTracking().Where(c => c.course_Id == sections.course_Id);
                    foreach (var courses in courseRespone)
                    {
                        Course courseObject = new Course(department, courses.number, courses.subject, courses.units, courses.description, new HashSet<string>(), new HashSet<string>(), courses.isLab);
                        Section sectionObject = new Section(courseObject, sections.sectionNumber, sections.schoolTerm, sections.schoolYear, sections.enrollmentCap, sections.waitListcap, sections.waitListTotal, classdays, sections.startTime, sections.endTime, sections.classLocation, null, sections.classNote, null, professor);
                        sectionsList.Add(sectionObject);
                        Console.WriteLine(courses.subject);
                    }
                }

            }
            return View(sectionsList);
        }
        public ActionResult sectiondescription()
        {
            return View();
        }
    }
}
