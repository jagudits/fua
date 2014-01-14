using System;
namespace QuestionsAndAnswers.Models
{
    public interface ITagRepository
    {
        void Add(tag tag);
        void Delete(tag tag);
        System.Linq.IQueryable<tag> FindAllTags();
        System.Linq.IQueryable<tag> FindTags(int limit);
        tag Get(int id);
        void Save();
    }
}
