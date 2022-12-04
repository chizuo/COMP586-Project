using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Registration.Models;
using Registration.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Registration.Controllers
{
    public class ProfessorController : Controller
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
                    Professor professor = new Professor(personRespone.id, personRespone.first, personRespone.last, personRespone.Gender, personRespone.birthMonth, personRespone.birthDay, personRespone.birthYear,
                                                        personRespone.address, personRespone.city, personRespone.state, personRespone.zip, personRespone.personType, null,
                                                        personRespone.middle, personRespone.email, personRespone.areaCode, personRespone.phone);

                    var departmentRespone = db.dbDepartments.Single(d => d.code == "COMP");
                    Department department = new Department(departmentRespone.name, departmentRespone.code, professor);

                    var scheduleRespone = db.dbEnrollmentSchedules.AsNoTracking().Where(e => e.id == login.id);

                    foreach (var schedule in scheduleRespone)
                    {
                        Console.WriteLine(schedule.sectionNumber);

                        var sectionRespone = db.dbSections.AsNoTracking().Where(s => s.sectionNumber == schedule.sectionNumber);
                        foreach (var section in sectionRespone)
                        {
                            Console.WriteLine(section.schoolTerm);
                            var courseRespone = db.dbCourses.AsNoTracking().Where(c => c.course_Id == section.course_Id);
                            foreach (var course in courseRespone)
                            {
                                Console.WriteLine(course.number);
                                Course courseObject = new Course(department, course.number, course.subject, course.units, course.description, new HashSet<string>(), new HashSet<string>(), course.isLab);
                                Section sectionObject = new Section(courseObject, section.sectionNumber, section.schoolTerm, section.schoolYear, section.enrollmentCap, section.waitListcap, section.waitListTotal, new string[] { "M", "W" }, section.startTime, section.endTime, section.classLocation, null, section.classNote, null, null);
                                professor.Sections.Add(sectionObject);
                            }
                        }   
                    }
                    return View("Dashboard", professor);
                }
            }
            /*
            if (db_login.ContainsKey(user.id) && user.password == db_login[user.id])
            {
            db_professors[user.id].Sections.Add(db_sections["section380"]);
            db_professors[user.id].Sections.Add(db_sections["section381"]);
            db_professors[user.id].Sections.Add(db_sections["section615"]);
            db_professors[user.id].Sections.Add(db_sections["section565"]);
            db_professors[user.id].Sections.Add(db_sections["section620"]);
            return View("Dashboard", db_professors[user.id]);
            }
            else
            {
                ViewData["message"] = "The credentials you entered are incorrect";
                return View("Index");
            }
            */
        }
    }
}
