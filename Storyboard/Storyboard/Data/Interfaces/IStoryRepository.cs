using Storyboard.Models;

namespace Storyboard.Data
{
    public interface IStoryRepository
    {
        public bool SaveChanges();
        public void AddEntity<T>(T entityToAdd);
        public void RemoveEntity<T>(T entityToRemove);
        public IEnumerable<Story> GetStories();
        public Story GetSingleStory(int storyId);
    }
}
