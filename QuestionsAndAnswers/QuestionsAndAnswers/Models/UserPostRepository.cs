﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionsAndAnswers.Models
{
    public class UserPostRepository : IUserPostRepository
    {
        private DataClasses1DataContext db = new DataClasses1DataContext();

        // Query Methods
        public System.Linq.IQueryable<user_post> FindAllUserPosts()
        {
            return from m in db.user_posts
                   select m;
        }

        public System.Linq.IQueryable<user_post> FindTopQuestions(int limit = 10)
        {
            return (from post in db.user_posts
                    where post.parent_post_id == 0
                    orderby post.ranking_points descending
                    select post).Take(limit);
        }

        public System.Linq.IQueryable<user_post> FindLatestQuestions(int limit = 10)
        {
            return (from post in db.user_posts
                    where post.parent_post_id == 0
                    orderby post.created_at descending
                    select post).Take(limit);
        }

        public System.Linq.IQueryable<user_post> FindLatestAnswers(int limit = 10)
        {
            return (from post in db.user_posts
                    where post.parent_post_id != 0
                    orderby post.created_at descending
                    select post).Take(limit);
        }

        public user_post Get(int id)
        {
            return db.user_posts.SingleOrDefault(d => d.id == id);
        }

        public System.Linq.IQueryable<user_post> GetPostChain(int id)
        {
            return (from post in db.user_posts
                    where post.id == id || post.parent_post_id == id
                    orderby post.created_at descending
                    select post);
        }

        public System.Linq.IQueryable<user_post> GetAnswers(int id)
        {
            return (from post in db.user_posts
                    where post.parent_post_id == id
                    orderby post.created_at descending
                    select post);
        }

        // Insert/Delete
        public void Add(user_post user_post)
        {
            db.user_posts.InsertOnSubmit(user_post);
        }

        public void Delete(user_post user_post)
        {
            db.user_posts.DeleteOnSubmit(user_post);
        }
        // Persistence
        public void Save()
        {
            db.SubmitChanges();
        }
    }
}