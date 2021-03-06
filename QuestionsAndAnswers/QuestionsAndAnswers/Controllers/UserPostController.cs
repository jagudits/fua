﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuestionsAndAnswers.Models;
using System.Diagnostics;


namespace QuestionsAndAnswers.Controllers
{
    public class UserPostController : Controller
    {
        IUserPostRepository userPostRepository;
        IUserRepository userRepository;

        public UserPostController()
            : this(new UserPostRepository(), new UserRepository())
        {
        }

        public UserPostController(IUserPostRepository upRepo, IUserRepository uRepo)
        {
            userPostRepository = upRepo;
            userRepository = uRepo;
        }

        //
        // GET: /UserPost/

        public ActionResult Index()
        {
            ViewBag.allUserPosts = userPostRepository.FindAllUserPosts();
            // user_post should be wrapped into UserPostViewModel

            return View(userPostRepository.FindAllUserPosts());
        }

        //
        // GET: /UserPost/Create

        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                //return RedirectToAction("Error", "Home", new { msg = "Please log on for adding post..." });
                return RedirectToAction("LogOn", "User", new { msg = "Please log on for adding post..." });
            }
        }

        //
        // POST: /UserPost/Create
        [HttpPost]
        public ActionResult Create(UserPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    user userLoggedOn = userRepository.GetByUsername(User.Identity.Name);
                    model.user_id = userLoggedOn.id;
                    model.parent_post_id = 0;
                    model.ranking_points = 0;
                    model.num_views = 0;
                    model.is_accepted_answer = false;
                    model.AddNew();
                    // what TODO
                    // should we check successful creation?
                    // should we redirect somewhere?
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home", new { msg = "Exception adding post..." });
                }

            }
            return View("Details", model);
        }

        //
        // GET: /UserPost/Details/2

        public ActionResult Details(int id)
        {
            var userPost = userPostRepository.Get(id);
            if (userPost == null)
                return View("NotFound");
            else
                return View(new UserPostViewModel(userPost));
        }

        //
        // GET: /UserPost/Edit/2

        public ActionResult Edit(int id)
        {
            if (Request.IsAuthenticated)
            {
                var userPost = userPostRepository.Get(id);
                if (userPost == null)
                    return View("NotFound");
                else
                    return View(new UserPostViewModel(userPost));
            }
            else
            {
                //return RedirectToAction("Error", "Home", new { msg = "Please log on for adding post..." });
                return RedirectToAction("LogOn", "User", new { msg = "Please log on for adding post..." });
            }
        }

        //
        // POST: /UserPost/Edit
        [HttpPost]
        public ActionResult Edit(int id, UserPostViewModel model)
        {
            user_post toEdit = userPostRepository.Get(id);

            if (ModelState.IsValid)
            {
                try
                {
                    model.ApplyChanges(toEdit);
                    userPostRepository.Save();
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home", new { msg = "Exception editing a post..." });
                }

            }
            return View("Details", model);
        }

        //
        // GET: /UserPost/Answer/2

        public ActionResult Answer(int id)
        {
            if (Request.IsAuthenticated)
            {
                var question = userPostRepository.Get(id);
                if (question == null)
                {
                    return View("NotFound");
                }
                else
                {
                    var answer = new UserPostViewModel();
                    answer.parent_post_id = question.id;
                    answer.title = "RE: " + question.title;
                    return View(answer);
                }
            }
            else
            {
                //return RedirectToAction("Error", "Home", new { msg = "Please log on for adding post..." });
                return RedirectToAction("LogOn", "User", new { msg = "Please log on for adding post..." });
            }

        }

        //
        // POST: /UserPost/Answer
        [HttpPost]
        public ActionResult Answer(UserPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddNew();
                    // what TODO
                    // should we check successful creation?
                    // should we redirect somewhere?
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home", new { msg = "Exception answering a post..." });
                }

            }
            return View("Details", model);
        }

    }
}
