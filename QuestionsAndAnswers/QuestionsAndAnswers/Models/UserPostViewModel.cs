using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace QuestionsAndAnswers.Models
{
    public class UserPostViewModel
    {
        public int id { get; private set; }

        [Required]
        [Display(Name = "Created by:")]
        public int user_id { get; set; }

        public System.Nullable<int> parent_post_id { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string content { get; set; }

        [Display(Name = "Ranking points:")]
        public int ranking_points { get; set; }

        [Display(Name = "Number of views:")]
        public int num_views;

        [Display(Name = "Accepted as answer:")]
        public bool is_accepted_answer { get; set; }

        [Display(Name = "Created at:")]
        public System.DateTime created_at { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }

        private user_post obj;

        private IUserPostRepository userPostRepository = new UserPostRepository();

        public UserPostViewModel()
        {
            obj = new user_post();

            // TODO trick?
            //obj.created_at = DateTime.Now;
        }

        public UserPostViewModel(user_post obj)
        {
            this.obj = obj;

            this.id = obj.id;
            this.user_id = obj.user_id;
            this.parent_post_id = obj.parent_post_id;
            this.title = obj.title;
            this.content = obj.content;
            this.ranking_points = obj.ranking_points;
            this.num_views = obj.num_views;
            this.is_accepted_answer = obj.is_accepted_answer;
            this.created_at = obj.created_at;
        }

        public void AddNew()
        {
            obj.id = this.id; // ???
            // TODO should we set user_id here and this way?
            obj.user_id = this.user_id;
            obj.parent_post_id = this.parent_post_id;
            obj.title = this.title;
            obj.content = this.content;
            obj.ranking_points = this.ranking_points;
            obj.num_views = this.num_views;
            obj.is_accepted_answer = this.is_accepted_answer;

            obj.created_at = DateTime.Now;
            userPostRepository.Add(obj);
            userPostRepository.Save();

        }

        public void ApplyChanges(user_post toEdit)
        {
            
            // TODO should we set user_id here and this way?
            toEdit.user_id = this.user_id;
            toEdit.parent_post_id = this.parent_post_id;
            toEdit.title = this.title;
            toEdit.content = this.content;
            toEdit.ranking_points = this.ranking_points;
            toEdit.num_views = this.num_views;
            toEdit.is_accepted_answer = this.is_accepted_answer;


        }
    }
}