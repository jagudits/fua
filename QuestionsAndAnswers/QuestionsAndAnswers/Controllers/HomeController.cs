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
            var users = from m in dataContext.users
                         select m;
            ViewBag.users = users;

            var topQuestions = from post
                               in dataContext.user_posts
                               where post.parent_post_id == 0
                               orderby post.ranking_points descending
                               select post;
            Console.WriteLine(topQuestions.ToString());
            ViewBag.topQuestions = topQuestions;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
