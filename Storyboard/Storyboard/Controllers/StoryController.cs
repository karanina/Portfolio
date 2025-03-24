using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Storyboard.Data;
using Storyboard.Data.Interfaces;
using Storyboard.DTOs;
using Storyboard.Models;

namespace Storyboard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoryController : ControllerBase
    {
          IStoryRepository _storyRepository;
        IMapper _mapper;

        public StoryController(IStoryRepository storyRepository;)
        {
            _storyRepository = storyRepository;
            _mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<StoryToAddDTO, Story>();
                })
            );
        }

        [HttpGet("GetStories")]
        public IEnumerable<Story> GetStories()
        {
            return _storyRepository.GetStories();
        }

        [HttpGet("GetSingleStory/{storyId}")]
        public Story GetSingleStory(int storyId)
        {
            return _storyRepository.GetSingleStory(storyId)
            
        }

        [HttpPut("EditStory")]
        public IActionResult EditStory(Story story)
        {
            Story? storyDb = _storyRepository.GetSingleStory(story.Id);

            if (storyDb != null)
            {
                storyDb.Title = story.Title;
                storyDb.Genre = story.Genre;

                if (_storyRepository.SaveChanges())
                {
                    return Ok();
                }
                throw new Exception("Failed to update Story");
            }
            throw new Exception("Failed to find Story");
        }

        [HttpPost("AddStory")]
        public IActionResult AddStory(StoryToAddDTO story)
        {
            Story storyDb = _mapper.Map<Story>(story);

            _storyRepository.AddEntity<Story>(storyDb);

            if (_storyRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Failed to add Story");
        }

        [HttpDelete("DeleteStory/{storyId}")]
        public IActionResult DeleteStory(int storyId)
        {
            Story? storyDb = _storyRepository.GetSingleStory(storyId);

            if (storyDb != null)
            {
                _storyRepository.RemoveEntity<Story>(storyDb);

                if (_storyRepository.SaveChanges())
                {
                    return Ok();
                }
                throw new Exception("Failed to delete Story");
            }
            throw new Exception("Failed to find Story");
        }
    }
}
