using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System;
using System.Web.Mvc;

namespace QuestionsAndAnswers.Models
{
    public class UserViewModel
    {
        private int id { get; private set; }
        [Required]
        private string username { get; set; }

        private string password { get; set; }

        private string password_retype { get; set; }

        private System.DateTime created_at { get; set; }
        [Required]
        private string email_address { get; set; }

        private bool is_admin { get; set; }

        private bool is_active { get; set; }

        private user obj;

        public UserViewModel()
        {
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

        public void ApplyChanges(user obj)
        {
            obj.username = this.username;
            obj.created_at = this.created_at;
            obj.email_address = this.email_address;
            obj.is_admin = this.is_admin;
            obj.is_active = this.is_active;
        }

        public void ApplyPassword(user obj, ModelStateDictionary modelState)
        {
            if (string.IsNullOrEmpty(password)) modelState.AddModelError("Password", "Password is required");
            if (string.IsNullOrEmpty(password_retype)) modelState.AddModelError("password_retype", "Please try again");
            if (password_retype != password) modelState.AddModelError("password_retype", "Must be the same as Password");

            obj.password = password;
        }
    }
}