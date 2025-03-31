using HouseholdAccounts.Data;
using Microsoft.AspNetCore.Mvc;
using HouseholdAccounts.Models;
using HouseholdAccounts.DTOs;
using Microsoft.AspNetCore.Authorization;
using HouseholdAccounts.Helpers;
using System.Reflection.Metadata;
using System;
using System.Data;
using static Azure.Core.HttpHeader;
using System.Transactions;
using Dapper;
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

        [HttpGet("GetTransactions/{accountID}/{accountOwnerID}/{transactionID}/{categoryID}/{transactionDate}/{startDateSearchTerm}/{endDateSearchTerm}/{payeeReferenceSearchTerm}")]
        public IEnumerable<DbTransaction> GetTransactions(
            int accountID,
            int accountOwnerID,
            int transactionID = 0,
            int categoryID = 0,
            DateTime transactionDate = default,
            DateTime startDateSearchTerm = default,
            DateTime endDateSearchTerm = default,
            string payeeReferenceSearchTerm = "None")
        {
            int userID = Convert.ToInt32(User.FindFirst("userID")?.Value);

            string sql = @"EXEC [Accounts].[spTransactions_Get] 
                            @UserID = @UserIDParam, 
                            @AccountID = @AccountIDParam, 
                            @AccountOwnerID = @AccountOwnerIDParam";
  
            DynamicParameters sqlParameters = new DynamicParameters();

            // Required parameters
            sqlParameters.Add("@UserIDParam", userID, DbType.Int32);
            sqlParameters.Add("@AccountIDParam", accountID, DbType.Int32);
            sqlParameters.Add("@AccountOwnerIDParam", accountOwnerID, DbType.Int32);

            // Nullable / Search parameters
            if (transactionID > 0)
            {
                sql += ", @TransactionID = @TransactionIDParam";
                sqlParameters.Add("TransactionIDParam", transactionID, DbType.Int32);
            }
            if (categoryID > 0)
            {
                sql += ", @CategoryID = @CategoryIDParam";
                sqlParameters.Add("CategoryIDParam", categoryID, DbType.Int32);
            }
            if (transactionDate != default)
            {
                sql += ", @TransactionDate = @TransactionDateParam";
                sqlParameters.Add("@TransactionDateParam", DateHelper.GetDate(transactionDate), DbType.Date);
            }
            if (startDateSearchTerm != default)
            {
                sql += ", @StartDateSearchTerm = @StartDateSearchTermParam";
                sqlParameters.Add("@StartDateSearchTermParam", DateHelper.GetDate(startDateSearchTerm), DbType.Date);
            }
            if (endDateSearchTerm != default)
            {
                sql += ", @EndDateSearchTerm = @EndDateSearchTermParam";
                sqlParameters.Add("@EndDateSearchTermParam", DateHelper.GetDate(endDateSearchTerm), DbType.Date);
            }
            if (payeeReferenceSearchTerm.ToLower() != "none")
            {
                sql += ", @PayeeReferenceSearchTerm = @PayeeReferenceSearchTermParam";
                sqlParameters.Add("@PayeeReferenceSearchTermParam", payeeReferenceSearchTerm, DbType.String);
            }

            return _dapper.LoadDataWithParameters<DbTransaction>(sql, sqlParameters);
        }

        [HttpPut("UpsertTransaction/{transaction}")]
        public IActionResult UpsertTransaction(DbTransactionToUpsertDTO transaction)
        {
            int userID = Convert.ToInt32(User.FindFirst("userID")?.Value);
            string sql = @"EXEC [Accounts].[spTransactions_Upsert] 
                            @AccountID = @AccountIDParam
                            @AccountOwnerID = @AccountOwnerIDParam,
                            @Payee = @PayeeParam,
                            @Notes = @NotesParam,
                            @Amount = @AmountParam,
                            @TranType = @TranTypeParam,
                            @BankUniqueID = @BankUniqueIDParam,
                            @TransactionDate = @TransactionDateParam,
                            @TransactionUpdatedByUserID = @TransactionUpdatedByUserIDParam";

            DynamicParameters sqlParameters = new DynamicParameters();
            
            // Required Parameters
            sqlParameters.Add("@AccountIDParam", transaction.AccountID, DbType.Int32);
            sqlParameters.Add("@AccountOwnerIDParam", transaction.AccountOwnerID, DbType.Int32);
            sqlParameters.Add("@PayeeParam", transaction.Payee, DbType.String);
            sqlParameters.Add("@NotesParam", transaction.Notes, DbType.String);
            sqlParameters.Add("@AmountParam", transaction.Amount, DbType.Decimal);
            sqlParameters.Add("@TranTypeParam", transaction.TranType, DbType.String);
            sqlParameters.Add("@BankUniqueIDParam", transaction.BankUniqueID, DbType.String);
            sqlParameters.Add("@TransactionDateParam", transaction.TransactionDateString, DbType.Date);
            sqlParameters.Add("@TransactionUpdatedByUserIDParam", userID, DbType.Int32);


            // Nullable Parameters
            if (transaction.GroupName != "")
            {
                sql += ", @GroupName = @GroupNameParam";
                sqlParameters.Add("@GroupNameParam", transaction.GroupName, DbType.String);
            }
            if (transaction.CategoryName != "")
            {
                sql += ", @CategoryName = @CategoryNameParam";
                sqlParameters.Add("@CategoryNameParam", transaction.CategoryName, DbType.String);
            }

            if (transaction.TransactionLoadedByUserID > 0)
            {
                sql += ", @TransactionLoadedByUserID = @TransactionLoadedByUserIDParam";
                sqlParameters.Add("@TransactionLoadedByUserIDParam", transaction.TransactionLoadedByUserID, DbType.Int32);
            }
            else
            {
                sql += ", @TransactionLoadedByUserID = @TransactionLoadedByUserIDParam";
                sqlParameters.Add("@TransactionLoadedByUserIDParam", userID, DbType.Int32);
            }

            if (transaction.ID > 0)
            {
                sql += $", @TransactionID = @TransactionIDParam";
                sqlParameters.Add("@TransactionIDParam", transaction.ID, DbType.Int32);
            }
            if (transaction.CategoryID > 0)
            {
                sql += $", @TransactionID = @CategoryIDParam";
                sqlParameters.Add("@CategoryIDParam", transaction.CategoryID, DbType.Int32);
            }

            if (_dapper.ExecuteSqlWithDynamicParameters(sql, sqlParameters))
            {
                return Ok();
            }
            throw new Exception("Failed to upsert Transaction");
        }

        
        [HttpDelete("DeleteTransaction/{transactionID}")]
        public IActionResult DeleteTransaction(int transactionID)
        {
            int userID = Convert.ToInt32(User.FindFirst("userID")?.Value);
            string sql = @$"EXEC [Accounts].[spTransactions_Delete] 
                            @TransactionID = @TransactionIDParam, 
                            @UserID = @UserIDParam";

            DynamicParameters sqlParameters = new DynamicParameters();

            sqlParameters.Add("@TransactionIDParam", transactionID, DbType.Int32);
            sqlParameters.Add("@UserIDParam", userID, DbType.Int32);

            if (_dapper.ExecuteSqlWithDynamicParameters(sql, sqlParameters))
            {
                return Ok();
            }
            throw new Exception("Failed to delete Transaction");
        }
    }
}
