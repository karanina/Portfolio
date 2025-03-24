using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;

namespace HouseholdAccounts.Data
{
    public class DataContextDapper
    {
        private readonly IConfiguration _config;

        public DataContextDapper(IConfiguration config)
        {
            // config holds the connection string to the database as held in the appsettings.json file
            _config = config;
        }

        public IEnumerable<T> LoadData<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.Query<T>(sql);

        }

        public T LoadDataSingle<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.QuerySingle<T>(sql);

        }

        // sql returns number of rows modified.
        public bool ExecuteSql(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.Execute(sql) > 0;
            // if execute is greater than zero, it's true
        }


        public int ExecuteSqlWithRowCount(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            return dbConnection.Execute(sql);

        }

        public bool ExecuteSqlWithParameters(string sql, List<SqlParameter> parameters)
        {
            SqlCommand commandWithParams = new SqlCommand(sql);

            foreach (SqlParameter param in parameters)
            {
                commandWithParams.Parameters.Add(param);
            }

            SqlConnection dbConnection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            dbConnection.Open();
            commandWithParams.Connection = dbConnection;
            int rowsAffected = commandWithParams.ExecuteNonQuery();
            dbConnection.Close();

            return rowsAffected > 0;
        }
    }
}