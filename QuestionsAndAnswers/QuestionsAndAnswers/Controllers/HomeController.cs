using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuestionsAndAnswers.Models;

namespace QuestionsAndAnswers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            var dataContext = new DataClasses1DataContext();
            var users = from m in dataContext.users
                         select m;

            ViewBag.users = users;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
