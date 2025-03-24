namespace Storyboard.Models
{
    // Represents a Story, and contains attributes that make up a story.
    public partial class Story
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }

        public Story()
        {
            if (Title == null)
            {
                Title = "";
            }
            if (Genre == null)
            {
                Genre = "";
            }
        }
    }
}
