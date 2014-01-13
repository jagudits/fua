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

            // top questions
            var topQuestions = from post
                               in dataContext.user_posts
                               where post.parent_post_id == 0
                               orderby post.ranking_points descending
                               select post;
            ViewBag.topQuestions = topQuestions;

            // newest questions
            var newestQuestions = from post
                                      in dataContext.user_posts
                                      where post.parent_post_id == 0
                                      orderby post.created_at descending
                                      select post;
            ViewBag.newestQuestions = newestQuestions;

            // newest answers
            ViewBag.newestAnswers = from post
                                    in dataContext.user_posts
                                    where post.parent_post_id != 0
                                    orderby post.created_at descending
                                    select post;

            // tags
            ViewBag.tags = from item
                           in dataContext.tags
                           select item;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
