using HouseholdAccounts.Data;
using Microsoft.AspNetCore.Mvc;
using HouseholdAccounts.Models;
using HouseholdAccounts.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Data.SqlTypes;
using System.Data;
using System;
using Dapper;
using HouseholdAccounts.Helpers;

namespace HouseholdAccounts.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContextDapper _dapper;
        private readonly ReusableSql _reusableSql;
        public UserController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
            _reusableSql = new ReusableSql(config);
        }

        // userId  and isActive are explicit parameters, so users know how to pass in the test value in order to get a correct response
        [HttpGet("GetUsers/{userId}/{isActive}")]
        public IEnumerable<User> GetUsers(int userID, bool isActive)
        {
            string sql = @"EXEC [Accounts].[spUsers_Get]";
            string stringParameters = "";
            DynamicParameters sqlParameters = new DynamicParameters();
            // 0 can be sent in as a placeholder for all users, if you want to get all users.
            if (userID != 0)
            {
                stringParameters += ", @UserID=@UserIParam";
                sqlParameters.Add("@UserIDParam", userID, DbType.Int32);
            }
            if (isActive)
            {
                stringParameters += ", @Active=@ActiveParam";
                sqlParameters.Add("@ActiveParam, isActive", DbType.Boolean);
            }
            if (stringParameters.Length > 0)
            {
                sql += stringParameters.Substring(1); //this removes the superflous comma at the beginning of the parameters string
            }
            return _dapper.LoadDataWithParameters<User>(sql, sqlParameters);
        }


        // IActionResult tells you what happened without returning a chunk of data, in this case failure or success
        [HttpPut("UpsertUser")]
        public IActionResult UpsertUser(User user)
        {
            if (_reusableSql.UpsertUser(user))
            {
                // Ok() comes from ControllerBase class, refers status code 200
                return Ok();
            }
            throw new Exception("Failed to upsert User");
        }

        [HttpDelete("DeactivateUser/{userID}")]
        public IActionResult DeactivateUser(int userID)
        {
            string sql = @$"EXEC [Accounts].[spUsers_Deactivate] 
                    @UserID = @UserIDParam";

            DynamicParameters sqlParameters = new DynamicParameters();
            sqlParameters.Add("UserIDParam", userID, DbType.Int32);

            if (_dapper.ExecuteSqlWithDynamicParameters(sql, sqlParameters))
            {
                // Ok() comes from ControllerBase class, refers status code 200
                return Ok();
            }
            throw new Exception("Failed to deactivate User");
        }
    }
}
