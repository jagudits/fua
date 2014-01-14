using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuestionsAndAnswers.Models;

namespace QuestionsAndAnswers.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.ApplyChanges();
                
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(UserViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
            }
            return View(model);
        }

        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

    }
}
