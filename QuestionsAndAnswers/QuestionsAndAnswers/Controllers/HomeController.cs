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
            ViewBag.Message = "Welcome to QuestionsAndAnswers!";

            // users
            var dataContext = new DataClasses1DataContext();

            UserRepository userRepo = new UserRepository();
            ViewBag.users = userRepo.FindActiveUsers();

            // top questions
            UserPostRepository userPostRepo = new UserPostRepository();
            ViewBag.topQuestions = userPostRepo.FindTopQuestions(10);

            // newest questions
            ViewBag.newestQuestions = userPostRepo.FindLatestQuestions(10); ;

            // newest answers
            ViewBag.newestAnswers = userPostRepo.FindLatestAnswers(10); ;

            // tags
            TagRepository tagRepo = new TagRepository();
            ViewBag.tags = tagRepo.FindAllTags();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
