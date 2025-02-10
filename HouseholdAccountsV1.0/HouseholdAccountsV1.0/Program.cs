using System;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;
using System.Text.RegularExpressions;
using Dapper;
using HouseholdAccountsV1._0.Data;
using HouseholdAccountsV1._0.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Configuration;

namespace HouseholdAccountsV1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // applies all the specifics in the appsettings file
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            DataContextDapper dapper = new DataContextDapper(config);

            //            DateTime rightNow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
            // // Integrated Security = true as I'm using Windows Authentication for the db
            // // TrustServerCertificate=True as I'm using a local db
            // // @ creates a verbatim string - treats the \ as a literal character ie not an escape character

            // string dbConnectionString =
            //     @"Server=LAPTOP-G5F4A124\SQLEXPRESS;Database=HouseholdAccountsDev;Integrated Security=true;TrustServerCertificate=True;";

            // IDbConnection dbConnection = new SqlConnection(dbConnectionString);
            // Console.WriteLine("Queries made using Dapper");

            // tests the database connection is active
            // string sqlCommand = "SELECT GETDATE()";
            // DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);
            //.Query or .QuerySingle to get data
            //.Execute to insert or update data
            // Console.WriteLine("" + rightNow.ToString());
            // Transaction aTransaction = new Transaction()
            // {
            //     ID = 1,
            //     Year = "2024",
            //     Month = "January",
            //     Day = "01",
            //     AccountOwner = "Anna",
            //     Notes = "Opening Balance",
            //     Amount = 47.79M,
            //     Category = 24,
            //     TransactionDate = new DateTime(2024, 1, 1),
            //     //myComputer.ReleaseDate.ToString("yyyy-MM-dd")
            // };
            // string sql =
            //     @"INSERT INTO [dbo].[Transaction]
            //         ([Year],
            //         [Month],
            //         [Day],
            //         [AccountOwner],
            //         [Notes],
            //         [Amount],
            //         [Category],
            //         [TransactionDate])
            //     VALUES
            //         ('"
            //     + aTransaction.Year
            //     + "','"
            //     + aTransaction.Month
            //     + "','"
            //     + aTransaction.Day
            //     + "','"
            //     + aTransaction.AccountOwner
            //     + "','"
            //     + aTransaction.Notes
            //     + "',"
            //     + aTransaction.Amount
            //     + ","
            //     + aTransaction.Category
            //     + ",'"
            //     + aTransaction.TransactionDate.ToString("yyyy-MM-dd")
            //     + "')";

            // Console.WriteLine(sql);
            // bool result = dapper.ExecuteSql(sql);

            // Console.WriteLine("DB Write successful =  " + result.ToString());

            // string sqlSelect =
            //     @"SELECT  [Year],
            //         t.[Month],
            //         t.[Day],
            //         t.[AccountOwner],
            //         t.[Notes],
            //         t.[Amount],
            //         t.[Category],
            //         t.[TransactionDate] From [dbo].[Transaction] as t";

            // IEnumerable<Transaction> transactions = dapper.LoadData<Transaction>(sqlSelect);
            // // IEnumerable is the return type of the query (multiple lines) call

            // foreach (Transaction row in transactions)
            // {
            //     Console.WriteLine(
            //         "'"
            //             + row.Year
            //             + "','"
            //             + row.Month
            //             + "','"
            //             + row.Day
            //             + "','"
            //             + row.AccountOwner
            //             + "','"
            //             + row.Notes
            //             + "',"
            //             + row.Amount
            //             + ","
            //             + row.Category
            //             + ",'"
            //             + row.TransactionDate.ToString("yyyy-MM-dd")
            //             + "'"
            //     );
            // }

            // File.WriteAllText("log.txt", sql);

            // using StreamWriter openFile = new StreamWriter("log.txt", append: true);
            // openFile.WriteLine(sql + "\n");
            // // need to remember to close the file so that it can be released from lock.
            // openFile.Close();

            String transactionsJson = File.ReadAllText("Transactions.json");
            //Console.WriteLine(transactionsJson);

            // in order to properly map between json and model given model uses Pascal case and json uses camel case
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            IEnumerable<Transaction>? transactionJson = JsonSerializer.Deserialize<
                IEnumerable<Transaction>
            >(transactionsJson, jsonOptions);

            if (transactionJson != null)
            {
                foreach (Transaction aTransaction in transactionJson)
                {
                    aTransaction.AccountOwner = "Anna";
                    //  Console.WriteLine(transaction.Amount.ToString());
                    string sql =
                        @"INSERT INTO [dbo].[Transaction]
                    ([Year],
                    [Month],
                    [Day],
                    [AccountOwner],
                    [Payee],
                    [Notes],
                    [Amount],
                    [Category],
                    [TranType],
                    [BankUniqueID],
                    [TransactionDate])
                VALUES
                    ('"
                        + aTransaction.Year
                        + "','"
                        + aTransaction.Month
                        + "','"
                        + aTransaction.Day
                        + "','"
                        + aTransaction.AccountOwner
                        + "','"
                        + EscapeSingleQuote(aTransaction.Payee)
                        + "','"
                        + EscapeSingleQuote(aTransaction.Notes)
                        + "',"
                        + aTransaction.Amount
                        + ","
                        + aTransaction.Category
                        + ",'"
                        + aTransaction.TranType
                        + "','"
                        + aTransaction.BankUniqueID
                        + "','"
                        + aTransaction.TransactionDate.ToString("yyyy-MM-dd")
                        + "')";

                   // Console.WriteLine(sql);
                    bool result = dapper.ExecuteSql(sql);

                    Console.WriteLine("DB Write successful =  " + result.ToString());
                }
            }

            string transactionsCopy = JsonSerializer.Serialize(transactionJson, jsonOptions);
            File.WriteAllText("TransactionsSerialized.txt", transactionsCopy);
        }

// for any string values that contain single appostrophies (eg in names)
        static string EscapeSingleQuote(string input){
            string output = input.Replace("'", "''");
            return output;
        }
    }
}
// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

// app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
