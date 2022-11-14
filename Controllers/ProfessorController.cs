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

        public ActionResult dashboard(User user)
        {
            if (db_login.ContainsKey(user.id) && user.password == db_login[user.id])
            {
                return View("Dashboard");
            }
            else
            {
                ViewData["message"] = "You have entered incorrect credentials";
                return View("Failure");
            }
        }

        public ActionResult section()
        {
            return View();
        }
    }
}