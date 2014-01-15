﻿using System;
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
        // GET: /UserPost/

        public ActionResult Index()
        {
            ViewBag.allUserPosts = userPostRepository.FindAllUserPosts();

            return View();
        }

        //
        // GET: /UserPost/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserPost/Create

        [HttpPost]
        public ActionResult Create(UserPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.ApplyChanges();

                // what TODO
                // should we check successful creation?
                // should we redirect somewhere?
            }
            return View(model);
        }

        //
        // GET: /UserPost/Details/2

        public ActionResult Details(int id)
        {
            var userPost = userPostRepository.Get(id);
            if (userPost == null)
                return View("NotFound");
            else
                return View(userPost);
        }

        //
        // GET: /UserPost/Edit/2

        public ActionResult Edit(int id)
        {
            var userPost = userPostRepository.Get(id);
            if (userPost == null)
                return View("NotFound");
            else
                return View(userPost);
        }
    }
}
