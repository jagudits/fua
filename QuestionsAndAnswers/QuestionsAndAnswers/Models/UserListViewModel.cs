using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QuestionsAndAnswers.Models
{
    public class UserListViewModel
    {
        public UserViewModel[] users { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

    }
}