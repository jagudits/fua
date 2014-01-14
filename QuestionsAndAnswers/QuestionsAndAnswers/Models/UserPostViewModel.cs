using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QuestionsAndAnswers.Models
{
    public class UserPostViewModel
    {
        public int id { get; private set; }

        [Required]
        public int user_id { get; set; }

        public System.Nullable<int> parent_post_id { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string content { get; set; }

        public int ranking_points { get; set; }

        public int num_views;

        public bool is_accepted_answer { get; set; }

        public System.DateTime created_at { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }

        private user_post obj;

        public UserPostViewModel()
        {
        }

        public UserPostViewModel(user_post obj)
        {
            this.id = obj.id;
            this.user_id = obj.user_id;
            this.parent_post_id = obj.parent_post_id;
            this.content = obj.content;
            this.ranking_points = obj.ranking_points;
            this.num_views = obj.num_views;
            this.is_accepted_answer = obj.is_accepted_answer;
            this.created_at = obj.created_at;
        }

        public void ApplyChanges(user_post obj)
        {
            obj.user_id = this.user_id;
            obj.parent_post_id = this.parent_post_id;
            obj.content = this.content;
            obj.ranking_points = this.ranking_points;
            obj.num_views = this.num_views;
            obj.is_accepted_answer = this.is_accepted_answer;
        }
    }
}