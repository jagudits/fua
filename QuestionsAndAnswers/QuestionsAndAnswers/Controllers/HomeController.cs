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
        IUserRepository userRepository;
        IUserPostRepository userPostRepository;
        ITagRepository tagRepository;

        public HomeController()
            : this(new UserRepository(), new UserPostRepository(), new TagRepository())
        {
        }

        public HomeController(IUserRepository uRepo, IUserPostRepository upRepo, ITagRepository tRepo)
        {
            userRepository = uRepo;
            userPostRepository = upRepo;
            tagRepository = tRepo;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to QuestionsAndAnswers!";

            // users
            var dataContext = new DataClasses1DataContext();

            ViewBag.users = userRepository.FindActiveUsers();

            // top questions
            ViewBag.topQuestions = userPostRepository.FindTopQuestions(10);

            // newest questions
            ViewBag.newestQuestions = userPostRepository.FindLatestQuestions(10); ;

            // newest answers
            ViewBag.newestAnswers = userPostRepository.FindLatestAnswers(10); ;

            // tags
            ViewBag.tags = tagRepository.FindAllTags();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Error(string msg = "No description available.")
        {
            ViewBag.msg = msg;

            return View();
        }
    }
}
