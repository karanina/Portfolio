using Storyboard.Models;

namespace Storyboard.Data
{
    public interface IUserRepository
    {
        public bool SaveChanges();
        public void AddEntity<T>(T entityToAdd);
        public void RemoveEntity<T>(T entityToRemove);
        public IEnumerable<User> GetUsers();
        public User GetSingleUser(int userId);

    }
}