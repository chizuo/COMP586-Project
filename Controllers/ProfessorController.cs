using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Registration.Models;

namespace Registration.Controllers
{
    public class ProfessorController : Controller
    {
        Dictionary<string, string> db_login = new Dictionary<string, string>();
        Dictionary<string, Professor> db_users = new Dictionary<string, Professor>();

        // GET: /Professor/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Index(string id, string password)
        {
            Welcome();
        }

        // GET: /Professor/Welcome/
        public IActionResult Welcome()
        {
            return View();
        }
    }
}