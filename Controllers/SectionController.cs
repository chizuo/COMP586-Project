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

        static HashSet<string> pre = new HashSet<string>();
        static HashSet<string> co = new HashSet<string>();
        public ActionResult sectionDescription(int sectionNumber)
        {

            using (var db = new Context())
            {
                var sectionRespone = db.dbSections.Single(s => s.sectionNumber == sectionNumber);
                var departmentRespone = db.dbDepartments.Single(d => d.code == sectionRespone.dept);
                var courseRespone = db.dbCourses.Single(c => c.course_Id == sectionRespone.course_Id);
                var professorRespone = db.dbPerson.Single(p => p.id == sectionRespone.professor);

                Professor professor = new Professor(professorRespone.id, professorRespone.first, professorRespone.last, professorRespone.Gender, professorRespone.birthMonth, professorRespone.birthDay, professorRespone.birthYear,
                                                                professorRespone.address, professorRespone.city, professorRespone.state, professorRespone.zip, professorRespone.personType, null,
                                                                professorRespone.middle, professorRespone.email, professorRespone.areaCode, professorRespone.phone);
                Department department = new Department(departmentRespone.name, departmentRespone.code, null);
                Course courseObject = new Course(department, courseRespone.number, courseRespone.subject, courseRespone.units, courseRespone.description, new HashSet<string>(), new HashSet<string>(), courseRespone.isLab);

                var preRespone = db.dbCourses.AsNoTracking().Where(pre => pre.course_Id == sectionRespone.course_Id);
                foreach (var preReq in preRespone)
                {
                    var prerequisites = db.dbCourses.AsNoTracking().Where(pre => pre.course_Id == sectionRespone.course_Id);
                    foreach (var preCourse in prerequisites)
                    {
                        Console.WriteLine(preCourse.course_Id);
                        pre.Add(preCourse.course_Id);
                    }
                }
                courseObject.PreRequisites = pre;

                var coRespone = db.dbCoReqs.AsNoTracking().Where(core => core.course_Id == sectionRespone.course_Id);
                foreach (var coReq in coRespone)
                {
                    var corequisites = db.dbCourses.AsNoTracking().Where(co => co.course_Id == sectionRespone.course_Id);
                    foreach (var coCourse in corequisites)
                    {
                        Console.WriteLine(coCourse.course_Id);
                        co.Add(coCourse.course_Id);
                    }
                }
                courseObject.CoRequisites = co;

                var classDaysRespone = db.dbClassDays.AsNoTracking().Where(d => d.sectionNumber == sectionNumber).ToArray();
                string[] classdays = new string[classDaysRespone.Length];
                for (int i = 0; i < classDaysRespone.Length; i++)
                {
                    classdays[i] = classDaysRespone[i].class_day;
                }

                Section section = new Section(courseObject, sectionRespone.sectionNumber, sectionRespone.schoolTerm, sectionRespone.schoolYear, sectionRespone.enrollmentCap, sectionRespone.waitListcap, sectionRespone.waitListTotal, classdays, sectionRespone.startTime, sectionRespone.endTime, sectionRespone.classLocation, null, sectionRespone.classNote, null, professor);
                
                return View(section);
            }
            
        }
        public ActionResult index()
        {
            return View();
        }
    }
}
