using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace QuestionsAndAnswers.Models
{
    public class UserViewModel
    {
        public int id { get; private set; }

        [Required]
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

        public UserViewModel()
        {
            obj = new user();
        }

        public UserViewModel(user obj)
        {
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
            UserRepository repo = new UserRepository();

            
            this.is_active = true;

            obj.username = this.username;
            //obj.created_at = new DateTime();
            obj.created_at = DateTime.Now;
            obj.email_address = this.email_address;
            obj.is_admin = this.is_admin;
            obj.is_active = this.is_active;
            obj.password = this.password;

            repo.Add(obj);
            

            repo.Save();

        }
    }
}