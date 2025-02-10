namespace Storyboard.Models
// Represents a Story, and contains attributes that make up a story.
{
    public class Story
    {
        public int ID { get; set; } = 0;
        public string Title { get; set; } = "";
        public string Genre { get; set; } = "";

        public Story()
        {
            // default constructor
        }
    }
}
