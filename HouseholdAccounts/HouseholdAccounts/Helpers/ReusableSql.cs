using Dapper;
using System.Data;
using HouseholdAccounts.Data;
using HouseholdAccounts.Models;

namespace HouseholdAccounts.Helpers
{
    public class ReusableSql
    {
        private readonly DataContextDapper _dapper;
        public ReusableSql(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }
        public bool UpsertUser(User user)
        {
            string sql = @$"EXEC [Accounts].[spUsers_Upsert]
                    @FirstName = @FirstNameParam,
                    @LastName = @LastNameParam,
                    @Email = @EmailParam,
                    @Active = @ActiveParam,
                    @DateCreated = @DateCreatedParam,
                    @UserID = @UserIDParam";

            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@FirstNameParam", user.FirstName, DbType.String);
            sqlParameters.Add("@LastNameParam", user.LastName, DbType.String);
            sqlParameters.Add("@EmailParam", user.Email, DbType.String);
            sqlParameters.Add("@ActiveParam", user.Active, DbType.Boolean);
            sqlParameters.Add("@DateCreatedParam", user.DateCreatedString, DbType.Date);
            sqlParameters.Add("@UserIDParam", user.ID, DbType.Int32);

            return _dapper.ExecuteSqlWithDynamicParameters(sql, sqlParameters);
        }

    }
}
