using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Registration.Models;

namespace Registration.Controllers
{
    public class SectionController : Controller
    {

        public ActionResult sectionsearch()
        {
            return View();
        }
    }
}
