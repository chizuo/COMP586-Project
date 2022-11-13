namespace Registration.Controllers;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Registration.Models;


public class LoginController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Index(UserModel model)
    {
        //Ignore this page (Work in Progress)

        // var username = model.UserName.FirstOrDefault();
        // var password = model.Password.FirstOrDefault(); 

        model.UserName = "admin";
        model.Password = "password";
        var username = "admin";
        var password = "admin";

        if (username == "admin" && password == "admin")
        {

            return View("Home");
        }
        else if (username == "User Does not Exists")

        {
            ViewBag.NotValidUser = username;

        }
        else
        {
            ViewBag.Failedcount = username;
        }

        return View("Index");
    }
}

