using Storyboard.Models;

namespace Storyboard.Data

{
    public class StoryRepository : IStoryRepository
    {
        DataContextEF _entityFramework;

        public StoryRepository(IConfiguration config)
        {
            _entityFramework = new DataContextEF(config);
        }

        public bool SaveChanges()
        {
            return _entityFramework.SaveChanges() > 0;
        }

        public void AddEntity<T>(T entityToAdd)
        {
            if (entityToAdd != null)
            {
                _entityFramework.Add(entityToAdd);
            }
        }

        public void RemoveEntity<T>(T entityToRemove)
        {
            if (entityToRemove != null)
            {
                _entityFramework.Remove(entityToRemove)
            }
        }

        public IEnumerable<Story> GetStories()
        {
            return _entityFramework.Stories.ToList<Story>();
        }

        public Story GetSingleStory(int storyId)
        {
            Story? story = _entityFramework
                .Stories.Where(s => s.Id == storyId)
                .FirstOrDefault<Story>();

            if (story != null)
            {
                return story;
            }
            throw new Exception("Failed to get Story");
        }        
    }
}
