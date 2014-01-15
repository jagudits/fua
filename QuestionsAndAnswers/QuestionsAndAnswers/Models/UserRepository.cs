﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionsAndAnswers.Models
{


    public class UserRepository : IUserRepository
    {
        private DataClasses1DataContext db = new DataClasses1DataContext();

        // Query Methods
        public System.Linq.IQueryable<user> FindAllUsers()
        {
            return from m in db.users
                   orderby m.username descending
                   select m;
        }
        public System.Linq.IQueryable<user> FindAllUsersWithWord(string word)
        {
            return (from m in db.users
                   orderby m.username descending
                   select m).Where(m => m.username.Contains('%'+word+'%'));
        }
        public System.Linq.IQueryable<user> FindActiveUsers()
        {
            return from m in db.users
                   where m.is_active == true
                   select m;
        }
        public user GetByUsername(string username)
        {
            return (from m in db.users
                    where m.username == username
                    select m).Single();
        }
        public bool UserExists(string username)
        {
            int cnt = (from m in db.users
                       where m.username == username
                       select m).Count();

            return (cnt > 0 ? true : false);
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

        public bool CheckPassword(string username, string password)
        {
            user user = GetByUsername(username);
            if (user == null) {
                return false;
            }

            return (user.password == password);
        }
        // Persistence
        public void Save()
        {
            db.SubmitChanges();
        }
    }
}