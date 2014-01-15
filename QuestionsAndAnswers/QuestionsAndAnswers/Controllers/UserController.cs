using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.Security;
using QuestionsAndAnswers.Models;
using System.Globalization;
using System.Diagnostics;

namespace QuestionsAndAnswers.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class UserController : Controller
    {
        IUserRepository userRepository;

        public UserController()
            : this(new UserRepository())
        {
        }

        public UserController(IUserRepository aRepo)
        {
            userRepository = aRepo;
        }

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

                try
                {
                    model.ApplyChanges();

                    //if no exception was thrown, check if the user creation was successfuland redirect
                    user new_user = userRepository.GetByUsername(model.username);
                    if (new_user != null)
                    {
                        return RedirectToAction("FakeUnlockMail", "User", new { id = new_user.id });
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home", new { msg = "Exception adding user..." });
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            ViewBag.msg = "";
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                if (userRepository.UserExists(model.UserName) && userRepository.CheckPassword(model.UserName, model.Password))
                {

                    //set cookie
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    user user = userRepository.GetByUsername(model.UserName);

                    if (!user.is_active) {
                        return RedirectToAction("Error", "Home", new { msg = "Account not activated..." });
                    }

                    if (user.is_admin)
                    {

                        Session.Add("role", "Admin");
                    }
                    else {

                        Session.Add("role", "User");
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.msg = "Wrong credentials. Please try again.";
            return View(model);
        }



        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Account/FakeUnlockMail

        public ActionResult FakeUnlockMail(int id)
        {
            user user = userRepository.Get(id);

            //handle error
            if (user == null)
            {
                return RedirectToAction("Error", "Home", new { msg = "User object was null..." });
            }

            ViewBag.user = new UserViewModel(user);

            return View();
        }

        //
        // GET: /Account/FakeUnlockMail

        public ActionResult UnlockUser(int id)
        {
            user user = userRepository.Get(id);

            //handle error
            if (user == null)
            {
                return RedirectToAction("Error", "Home", new { msg = "User object was null..." });
            }

            UserViewModel model = new UserViewModel(user);
            //activate account
            try
            {
                model.is_active = true;
                model.ApplyChanges();
                userRepository.Save();
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home", new { msg = "Exception caught while saving data: " + e.Message });
            }


            ViewBag.user = model;
            


            return View();
        }



        //
        // GET: /User/List

        public ActionResult List()
        {
            if (!Request.IsAuthenticated || (string)(@Session["role"]) != "Admin")
            {
                return RedirectToAction("Error", "Home", new { msg = "You are not allowed to view this page..." });
            }

            System.Linq.IQueryable<user> list = userRepository.FindAllUsers();
            UserViewModel[] users = new UserViewModel[list.Count()];
            int i = 0;
            foreach (user u in list)
            {
                users[i] = new UserViewModel(u);
                i++;
            }


            UserListViewModel ulVM = new UserListViewModel();
            ulVM.users = users;
            
            return View(ulVM);
        }

        //
        // POST: /User/List

        [HttpPost]
        public ActionResult List(UserListViewModel ulVM)
        {
            if (!Request.IsAuthenticated || @Session["role"] != "Admin")
            {
                return RedirectToAction("Error", "Home", new { msg = "You are not allowed to view this page..." });
            }

            Debug.WriteLine("SEARCHT IS " + ulVM.UserName);
            System.Linq.IQueryable<user> list = userRepository.FindAllUsersWithWord(ulVM.UserName);
            UserViewModel[] users = new UserViewModel[list.Count()];
            int i = 0;
            foreach (user u in list)
            {
                users[i] = new UserViewModel(u);
                i++;
            }

            ulVM.users = users;

            return View(ulVM);
        }


        /**
         *AJAX ACTIONS
         **/

        public JsonResult IsUsernameAvailable(string Username)
        {
            if (!userRepository.UserExists(Username))
                return Json(true, JsonRequestBehavior.AllowGet);

            string suggestedUID = String.Format(CultureInfo.InvariantCulture,
                "{0} is not available.", Username);

            for (int i = 1; i < 100; i++)
            {
                string altCandidate = Username + i.ToString();
                if (!userRepository.UserExists(altCandidate))
                {
                    suggestedUID = String.Format(CultureInfo.InvariantCulture,
                   "{0} has already been taken. But {1} is still available!", Username, altCandidate);
                    break;
                }
            }
            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
        }

    }
}