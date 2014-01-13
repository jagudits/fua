using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionsAndAnswers.Models
{
    public class TagRepository
    {
        private DataClasses1DataContext db = new DataClasses1DataContext();

        // Query Methods
        public System.Linq.IQueryable<tag> FindAllTags()
        {
            return from m in db.tags
                   select m;
        }

        public System.Linq.IQueryable<tag> FindTags(int limit)
        {
            return (from m in db.tags
                    select m).Take(limit);
        }

        public tag Get(int id)
        {
            return db.tags.SingleOrDefault(d => d.id == id);
        }

        // Insert/Delete
        public void Add(tag tag)
        {
            db.tags.InsertOnSubmit(tag);
        }

        public void Delete(tag tag)
        {
            db.tags.DeleteOnSubmit(tag);
        }
        // Persistence
        public void Save()
        {
            db.SubmitChanges();
        }
    }
}