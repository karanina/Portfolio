// this file is for the Dapper version of database queries
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using Dapper;
using Microsoft.Data.SqlClient;

namespace HouseholdAccountsV1._0.Data
{
    public class DataContextDapper
    {
        private IConfiguration _config;
        private string _dbConnectionString;

        // Integrated Security = true as I'm using Windows Authentication for the db
        // TrustServerCertificate=True as I'm using a local db
        // @ creates a verbatim string - treats the \ as a literal character ie not an escape character
        //     @"Server=LAPTOP-G5F4A124\SQLEXPRESS;Database=HouseholdAccountsDev;Integrated Security=true;TrustServerCertificate=True;";

        public DataContextDapper(IConfiguration config)
        {
            try
            {
                _config = config;
                _dbConnectionString = config.GetConnectionString("DefaultConnection");
            }
            catch (Exception ex)
            {
                _dbConnectionString = "";
                throw new Exception("No connection string found", ex);
            }
        }

        // <T> = generic Type is defined when calling the method
        // loads (potentially) multiple rows
        public IEnumerable<T> LoadData<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            return dbConnection.Query<T>(sql);
        }

        // <T> = generic Type is defined when calling the method
        // loads single row
        public T LoadDataSingle<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            return dbConnection.QuerySingle<T>(sql);
        }

        // executes insert or update sql statement
        // returns boolean to check the number of rows affected is greater than 0
        public bool ExecuteSql(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            return (dbConnection.Execute(sql) > 0);
        }

        // executes insert or update sql statement
        // returns number of rows affected
        public int ExecuteSqlWithRowCount(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            return dbConnection.Execute(sql);
        }
    }
}
