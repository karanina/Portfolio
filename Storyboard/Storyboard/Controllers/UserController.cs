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
    public class UserController : ControllerBase
    {
        IUserRepository _userRepository;
        IMapper _mapper;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserToAddDTO, User>();
                })
            );
        }

        [HttpGet("GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        [HttpGet("GetSingleUser/{userId}")]
        public User GetSingleUser(int userId)
        {
            return _userRepository.GetSingleUser(userId);
        }

        [HttpPut("EditUser")]
        public IActionResult EditUser(User user)
        {
            User? userDb = _userRepository.GetSingleUser(user.UserId)

            if (userDb != null)
            {
                userDb.Username = user.Username;
                userDb.FirstName = user.FirstName;
                userDb.LastName = user.LastName;
                userDb.Email = user.Email;
                userDb.Active = user.Active;

                if (_userRepository.SaveChanges())
                {
                    return Ok();
                }
                throw new Exception("Failed to update User");
            }
            throw new Exception("Failed to update User");
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(UserToAddDTO user)
        {
            // maps the UserToAddDTO class to the User class, so we don't need to go through all the fields
            // and assign them one by one.
            User userDb = _mapper.Map<User>(user);

            _userRepository.AddEntity<User>(userDb);
            if (_userRepository.SaveChanges())
            {
                return Ok();
            }
            throw new Exception("Failed to add User");
        }

        [HttpDelete("DeleteUser/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            User? userDb = _userRepository.GetSingleUser(userId);

            if (userDb != null)
            {
                _userRepository.RemoveEntity<User>(userDb);
                if (_userRepository.SaveChanges())
                {
                    return Ok();
                }
                throw new Exception("Failed to delete User");
            }
            throw new Exception("Failed to delete User");
        }
    }
}
