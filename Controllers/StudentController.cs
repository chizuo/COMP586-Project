using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Registration.Models;
using Registration.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Registration.Controllers
{
    public class StudentController : Controller
    {
        // GET: /Professor/
        public ActionResult index()
        {
            ViewData["message"] = "";
            return View();
        }

        public ActionResult dashboard(Login login)
        {
            using (var db = new Context())
            {
                var status = db.login.Where(m => m.id == login.id && m.password == login.password).FirstOrDefault();
                if (status == null)
                {
                    ViewData["message"] = "The credentials you entered are incorrect";
                    return View("Index");
                }

                else
                {
        
                    var personRespone = db.dbPerson.Single(p => p.id == login.id);
                    Student student = new Student(personRespone.id, personRespone.first, personRespone.last, personRespone.Gender, personRespone.birthMonth, personRespone.birthDay, personRespone.birthYear,
                                                        personRespone.address, personRespone.city, personRespone.state, personRespone.zip, personRespone.personType, null, null,
                                                        personRespone.middle, personRespone.email, personRespone.areaCode, personRespone.phone, null);
                    //
                    var departmentRespone = db.dbDepartments.Single(d => d.code == "COMP");
                    Department department = new Department(departmentRespone.name, departmentRespone.code, null);

                    var scheduleRespone = db.dbEnrollmentSchedules.AsNoTracking().Where(e => e.id == login.id);

                    foreach (var schedule in scheduleRespone)
                    {
                        Console.WriteLine(schedule.sectionNumber);

                        var sectionRespone = db.dbSections.AsNoTracking().Where(s => s.sectionNumber == schedule.sectionNumber);
                        foreach (var section in sectionRespone)
                        {
                            List<Section> sections = new List<Section>();
                            
                            var classDaysRespone = db.dbClassDays.AsNoTracking().Where(d => d.sectionNumber == section.sectionNumber).ToArray();
                            string[] classDays = new string[classDaysRespone.Length];
                            for(int i = 0; i < classDays.Length; i++)
                            {
                                classDays[i] = classDaysRespone[i].class_day;
                            }

                            Console.WriteLine(section.schoolTerm);
                            var courseRespone = db.dbCourses.AsNoTracking().Where(c => c.course_Id == section.course_Id);
                            foreach (var course in courseRespone)
                            {
                                Console.WriteLine(course.number);
                                Course courseObject = new Course(department, course.number, course.subject, course.units, course.description, new HashSet<string>(), new HashSet<string>(), course.isLab);
                                Section sectionObject = new Section(courseObject, section.sectionNumber, section.schoolTerm, section.schoolYear, section.enrollmentCap, section.waitListcap, section.waitListTotal, classDays, section.startTime, section.endTime, section.classLocation, null, section.classNote, null, null);
                                student.Sections.Add(sectionObject);
                                /*
                                for(int i = 0; i < classDays.Length; i++)
                                {
                                    student.Schedule.Add(classDays[i], sections);
                                }
                                */
                            }
                        }   
                    }
                    return View("Dashboard", student);
                }
            }
        }
    }
}
