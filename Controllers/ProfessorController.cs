using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Registration.Controllers
{
    public class ProfessorController : Controller
    {
        // GET: /Professor/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Professor/Welcome/
        public IActionResult Welcome()
        {
            return View();
        }
    }
}