namespace Storyboard.DTOs
{
    public class StoryToAddDTO
    {
        public string? Title { get; set; }
        public string? Genre { get; set; }

        public StoryToAddDTO()
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
