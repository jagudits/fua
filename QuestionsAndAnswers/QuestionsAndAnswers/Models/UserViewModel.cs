using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Diagnostics;
using System.Web.Security;

namespace QuestionsAndAnswers.Models
{
    public class UserViewModel
    {
        public int id { get; private set; }

        [Required]
        [Remote("IsUsernameAvailable", "User")]
        [Display(Name = "User name")]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string password_retype { get; set; }

        public System.DateTime created_at { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string email_address { get; set; }

        public bool is_admin { get; set; }

        public bool is_active { get; set; }

        private user obj;

        private IUserRepository userRepository = new UserRepository();

        public UserViewModel()
        {
            obj = new user();
        }

        public UserViewModel(user obj)
        {
            this.obj = obj;

            this.id = obj.id;
            this.username = obj.username;
            this.password = obj.password;
            this.created_at = obj.created_at;
            this.email_address = obj.email_address;
            this.is_admin = obj.is_admin;
            this.is_active = obj.is_active;
        }

        public void ApplyChanges()
        {
            obj.username = this.username;
            obj.email_address = this.email_address;
            obj.is_admin = this.is_admin;
            Debug.WriteLine("internal is active = "+ (this.is_active));
            obj.is_active = this.is_active;
            Debug.WriteLine("object is active = " + (obj.is_active));
            obj.password = this.password;

            if (obj.id == 0)
            {
                Debug.WriteLine("id is null, adding user");
                obj.created_at = DateTime.Now;
                userRepository.Add(obj);
            }
            userRepository.Save();

        }

        public bool isLoggedOn() { 
            //return FormsAuthentication.

            return true;
        }
    }
}