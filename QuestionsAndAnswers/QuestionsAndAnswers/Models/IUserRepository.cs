using System;
namespace QuestionsAndAnswers.Models
{
    public interface IUserRepository
    {
        void Add(user user);
        void Delete(user user);
        System.Linq.IQueryable<user> FindActiveUsers();
        System.Linq.IQueryable<user> FindAllUsers();
        System.Linq.IQueryable<user> FindAllUsersWithWord(string word);
        user Get(int id);
        user GetByUsername(string username);
        void Save();
        bool CheckPassword(string username, string password);
        bool UserExists(string username);
    }
}
