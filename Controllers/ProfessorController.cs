using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Registration.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /Professor/
        public string Index()
        {
            return "This is my default action...";
        }

        // GET: /Professor/Welcome/ //
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}