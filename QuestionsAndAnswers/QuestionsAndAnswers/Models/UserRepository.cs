﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionsAndAnswers.Models
{


    public class UserRepository
    {
        private DataClasses1DataContext db = new DataClasses1DataContext();

        // Query Methods
        public System.Linq.IQueryable<user> FindAllUsers()
        {
            return from m in db.users
                   select m;
        }
        public System.Linq.IQueryable<user> FindActiveUsers()
        {
            return from m in db.users
                   where m.is_active == true
                   select m;
        }

        public user Get(int id)
        {
            return db.users.SingleOrDefault(d => d.id == id);
        }

        // Insert/Delete
        public void Add(user user)
        {
            db.users.InsertOnSubmit(user);
        }

        public void Delete(user user)
        {
            user.is_active = false;
        }
        // Persistence
        public void Save() {
            db.SubmitChanges();
        }
    }
}