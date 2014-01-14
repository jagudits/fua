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
        IUserPostRepository userPostRepository;

        public UserPostController()
            : this(new UserPostRepository())
        {
        }

        public UserPostController(IUserPostRepository aRepo)
        {
            userPostRepository = aRepo;
        }

        //
        // GET: /Question/

        public ActionResult Index()
        {
            ViewBag.allQuestions = userPostRepository.FindAllUserPosts();

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
            var userPost = userPostRepository.Get(id);
            if (userPost == null)
                return View();
            else
                return View();
        }

    }
}
