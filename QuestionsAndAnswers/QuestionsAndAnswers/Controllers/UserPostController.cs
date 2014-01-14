using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuestionsAndAnswers.Models;


namespace QuestionsAndAnswers.Controllers
{
    public class UserPostController : Controller
    {
        UserPostRepository userPostRepo = new UserPostRepository();

        //
        // GET: /Question/

        public ActionResult Index()
        {
            ViewBag.allQuestions = userPostRepo.FindAllUserPosts();

            return View();
        }

        //
        // GET: /Question/

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Question/Create

        [HttpPost]
        public ActionResult Create(UserPostViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
                
        //
        // GET: /Question/Details/2

        public ActionResult Details(int id)
        {
            var userPost = userPostRepo.Get(id);
            if (userPost == null)
                return View();
            else
                return View();
        }

    }
}
