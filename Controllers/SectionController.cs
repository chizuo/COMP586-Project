using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Registration.Models;

namespace Registration.Section
{
    public class SectionController : Controller
    {

        public ActionResult sectionsearch()
        {
            return View();
        }
    }
}
