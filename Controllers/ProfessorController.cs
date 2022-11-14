using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Registration.Models;

namespace Registration.Controllers
{
    public class ProfessorController : Controller
    {
        Dictionary<string, string> db_login = new Dictionary<string, string>() { { "123456789", "Comp#586" } };
        Dictionary<string, Professor> db_users = new Dictionary<string, Professor>();

        // GET: /Professor/
        public ActionResult index()
        {
            return View();
        }

        public ActionResult dashboard(string id, string password)
        {
            if (db_login.ContainsKey(id) && password == db_login[id])
            {
                ViewBag.ID = id;
                ViewBag.password = password;
                return View("Dashboard");
            }
            else
            {
                ViewData["message"] = "You have entered incorrect credentials";
                return View("Failure");
            }
        }
    }
}