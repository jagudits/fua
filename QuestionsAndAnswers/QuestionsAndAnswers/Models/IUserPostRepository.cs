using System;
namespace QuestionsAndAnswers.Models
{
    public interface IUserPostRepository
    {
        void Add(user_post user_post);
        void Delete(user_post user_post);
        System.Linq.IQueryable<user_post> FindAllUserPosts();
        System.Linq.IQueryable<user_post> FindLatestAnswers(int limit = 10);
        System.Linq.IQueryable<user_post> FindLatestQuestions(int limit = 10);
        System.Linq.IQueryable<user_post> FindTopQuestions(int limit = 10);
        user_post Get(int id);
        void Save();
    }
}
