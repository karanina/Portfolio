using HouseholdAccounts.Data;
using Microsoft.AspNetCore.Mvc;
using HouseholdAccounts.Models;
using HouseholdAccounts.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Data.SqlTypes;

namespace HouseholdAccounts.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        DataContextDapper _dapper;
        public UserController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

       // [HttpGet("GetUsers/{userId}/{isActive}")]
        [HttpGet("GetUsers")]
       // public IEnumerable<User> GetUsers(int userID, bool isActive)
        public IEnumerable<User> GetUsers()
        {
            // replace sql query with stored procedures
            //string sql = @"EXEC [dbo].[spUsers_Get]";
            string parameters = "";
            // 0 can be sent in as a placeholder for all users, if you want to get all users.
            //if (userID != 0)
            //{
            //parameters += ", @UserID=" + userID.ToString();
            //}
            //if (isActive)
            //{
            //parameters += ", @Active=" + isActive;
            //}
            // sql += parameters.Substring(1) //this removes the superflous comma at the beginning of the parameters string
            string sql = @"
                SELECT UserId, 
                    Username, 
                    FirstName, 
                    LastName, 
                    Email, 
                    Active 
                FROM dbo.Users";
            return _dapper.LoadData<User>(sql);
        }

        // userId is an explicit parameter, so users know how to pass in the test value in order to get a correct response
        [HttpGet("GetSingleUser/{userId}")]
        public User GetSingleUser(int userId)
        {
            string sql = @$"
                SELECT UserId, 
                    Username, 
                    FirstName, 
                    LastName, 
                    Email, 
                    Active 
                FROM dbo.Users 
                WHERE UserId = {userId}";
            return _dapper.LoadDataSingle<User>(sql);
        }

        // IActionResult tells you what happened without returning a chunk of data, in this case failure or success
        [HttpPut("EditUser")]
        public IActionResult EditUser(User user)
        {
            string sql = @$"
                UPDATE dbo.Users
                SET Username = '{user.Username}',
                    FirstName = '{user.FirstName}',
                    LastName = '{user.LastName}',
                    Email = '{user.Email}',
                    Active = '{user.Active}'
                WHERE UserId = {user.UserId}";
            Console.WriteLine(sql);
            if (_dapper.ExecuteSql(sql))
            {
                // Ok() comes from ControllerBase class, refers status code 200
                return Ok();
            }
            throw new Exception("Failed to update User");    
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(UserToAddDTO user)
        {
            string sql = @$"
                INSERT INTO dbo.Users (
                    Username, 
                    FirstName, 
                    LastName, 
                    Email, 
                    Active
                ) VALUES (
                    '{user.Username}',
                    '{user.FirstName}',
                    '{user.LastName}',
                    '{user.Email}',            
                    '{user.Active}'
                )";
            Console.WriteLine(sql);
            if (_dapper.ExecuteSql(sql))
            {
                // Ok() comes from ControllerBase class, refers status code 200
                return Ok();
            }
            throw new Exception("Failed to add User");
        }

        [HttpDelete("DeleteUser/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            string sql = @$"
                    DELETE FROM dbo.Users 
                    WHERE UserId = {userId}";

            if (_dapper.ExecuteSql(sql))
            {
                // Ok() comes from ControllerBase class, refers status code 200
                return Ok();
            }
            throw new Exception("Failed to delete User");
        }

        [HttpGet("TestConnection")]
        public DateTime TestConnection()
        {
            return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE();");
        }

    }
}
