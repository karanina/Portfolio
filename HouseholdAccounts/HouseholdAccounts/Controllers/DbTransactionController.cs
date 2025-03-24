using HouseholdAccounts.Data;
using Microsoft.AspNetCore.Mvc;
using HouseholdAccounts.Models;
using HouseholdAccounts.DTOs;
using Microsoft.AspNetCore.Authorization;
using HouseholdAccounts.Helpers;
namespace HouseholdAccounts.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DbTransactionController : ControllerBase
    {
        DataContextDapper _dapper;

        public DbTransactionController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpGet("GetTransactions")]
        public IEnumerable<DbTransaction> GetTransactions()
        {
            string sql = @"
                SELECT [ID], 
                    [Year], 
                    [Month], 
                    [Day], 
                    [Account], 
                    [AccountOwner], 
                    [Payee], 
                    [Notes], 
                    [Amount], 
                    [Category], 
                    [TranType], 
                    [BankUniqueID], 
                    [TransactionDate],
                    [TransactionLoaded],
                    [TransactionLoadedBy],
                    [TransactionUpdated],
                    [TransactionUpdatedBy]
                FROM [dbo].[Transaction]";
            return _dapper.LoadData<DbTransaction>(sql);
        }

        [HttpGet("GetSingleTransaction/{transactionId}")]
        public DbTransaction GetSingleTransaction(int transactionId)
        {
            string sql = @$"
                SELECT [ID], 
                    [Year], 
                    [Month], 
                    [Day], 
                    [Account], 
                    [AccountOwner], 
                    [Payee], 
                    [Notes], 
                    [Amount], 
                    [Category], 
                    [TranType], 
                    [BankUniqueID], 
                    [TransactionDate],
                    [TransactionLoaded],
                    [TransactionLoadedBy],
                    [TransactionUpdated],
                    [TransactionUpdatedBy]
                FROM [dbo].[Transaction]
                WHERE [ID] = {transactionId}";
            return _dapper.LoadDataSingle<DbTransaction>(sql);
        }


        [HttpGet("GetTransactionsByAccountOwner/{accountOwner}")]
        public IEnumerable<DbTransaction> GetTransactionsByAccountOwner(string accountOwner)
        {
            string sql = @$"
                SELECT [ID], 
                    [Year], 
                    [Month], 
                    [Day], 
                    [Account], 
                    [AccountOwner], 
                    [Payee], 
                    [Notes], 
                    [Amount], 
                    [Category], 
                    [TranType], 
                    [BankUniqueID], 
                    [TransactionDate],
                    [TransactionLoaded],
                    [TransactionLoadedBy],
                    [TransactionUpdated],
                    [TransactionUpdatedBy]
                FROM [dbo].[Transaction]
                WHERE[AccountOwner] = {accountOwner}";
            return _dapper.LoadData<DbTransaction>(sql);
        }


        [HttpGet("GetTransactionsByCategory/{category}")]
        public IEnumerable<DbTransaction> GetTransactionsByCategory(int category)
        {
            string sql = @$"
                SELECT [ID], 
                    [Year], 
                    [Month], 
                    [Day], 
                    [Account], 
                    [AccountOwner], 
                    [Payee], 
                    [Notes], 
                    [Amount], 
                    [Category], 
                    [TranType], 
                    [BankUniqueID], 
                    [TransactionDate],
                    [TransactionLoaded],
                    [TransactionLoadedBy],
                    [TransactionUpdated],
                    [TransactionUpdatedBy]
                FROM [dbo].[Transaction]
                WHERE[Category] = {category}";
            return _dapper.LoadData<DbTransaction>(sql);
        }


        [HttpGet("GetTransactionsBetweenDates")]
        public IEnumerable<DbTransaction> GetTransactionsBetweenDates(string startDate, string endDate)
        {
            if (DateHelper.TryDateParse(startDate) && DateHelper.TryDateParse(endDate))
            {
                string sql = @$"
                SELECT [ID], 
                    [Year], 
                    [Month], 
                    [Day], 
                    [Account], 
                    [AccountOwner], 
                    [Payee], 
                    [Notes], 
                    [Amount], 
                    [Category], 
                    [TranType], 
                    [BankUniqueID], 
                    [TransactionDate],
                    [TransactionLoaded],
                    [TransactionLoadedBy],
                    [TransactionUpdated],
                    [TransactionUpdatedBy]
                FROM [dbo].[Transaction]
                WHERE[TransactionDate] BETWEEN '{startDate}' AND '{endDate}'";
                return _dapper.LoadData<DbTransaction>(sql);
            }
            throw new ArgumentException("Dates in incorrect format. Should be in 'yyyy-MM-dd' format.");
        }

        [HttpPut("EditTransaction/{transaction}")]
        public IActionResult EditTransaction(DbTransactionToEditDTO transaction)
        {
            string sql = @$"
                UPDATE [dbo].[Transaction]
                SET [Year] = '{transaction.Year}', 
                    [Month] = '{transaction.Month}', 
                    [Day] = '{transaction.Day}', 
                    [Account] = '{transaction.Account}', 
                    [AccountOwner] = '{transaction.AccountOwner}', 
                    [Payee] = '{transaction.Payee}', 
                    [Notes] = '{transaction.Notes}', 
                    [Amount] = {transaction.Amount}, 
                    [Category] = {transaction.Category}, 
                    [TranType] = '{transaction.TranType}', 
                    [BankUniqueID] = '{transaction.BankUniqueID}', 
                    [TransactionDate] = '{transaction.TransactionDateString}',
                    [TransactionLoaded] = '{transaction.TransactionLoadedString}',
                    [TransactionLoadedBy] = {transaction.TransactionLoadedBy},
                    [TransactionUpdated] = GETDATE(),
                    [TransactionUpdatedBy] = {this.User.FindFirst("userId")?.Value}
                WHERE [ID] = {transaction.ID}";

            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to update Transaction");
        }

        [HttpPost("AddTransaction")]
        public IActionResult AddTransaction(DbTransactionToAddDTO transaction)
        {
            int addedByUser = Convert.ToInt32(this.User.FindFirst("userId")?.Value);
            string sql = @$"
                INSERT INTO [dbo].[Transaction] (
                    [Year], 
                    [Month], 
                    [Day], 
                    [Account], 
                    [AccountOwner], 
                    [Payee], 
                    [Notes], 
                    [Amount], 
                    [Category], 
                    [TranType], 
                    [BankUniqueID], 
                    [TransactionDate],
                    [TransactionLoaded],
                    [TransactionLoadedBy],
                    [TransactionUpdated],
                    [TransactionUpdatedBy]
                ) VALUES (
                    '{transaction.Year}', 
                    '{transaction.Month}', 
                    '{transaction.Day}', 
                    '{transaction.Account}', 
                    '{transaction.AccountOwner}', 
                    '{transaction.Payee}', 
                    '{transaction.Notes}', 
                    {transaction.Amount}, 
                    {transaction.Category}, 
                    '{transaction.TranType}', 
                    '{transaction.BankUniqueID}', 
                    '{transaction.TransactionDateString}',
                    GETDATE(),
                    {this.User.FindFirst("userId")?.Value},
                    GETDATE(),
                    {this.User.FindFirst("userId")?.Value}
                )";

            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to add Transaction");
        }

        [HttpDelete("DeleteTransaction/{transactionId}")]
        public IActionResult DeleteTransaction(int transactionId)
        {
            string sql = @$"
                DELETE FROM [dbo].[Transaction] 
                WHERE ID = {transactionId}";
            if (_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            throw new Exception("Failed to delete Transaction");
        }
    }
}
