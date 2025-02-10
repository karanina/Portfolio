using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Storyboard.Data;
using Storyboard.Models;

namespace Storyboard
{
    internal class Storyboard
    {
        static void Main(string[] args)
        {
            // applies all the specifics in the appsettings file
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            DataContextEF entityFramework = new DataContextEF(config);

            // Story aStory = new Story()
            // {
            //     Title = "The man in the plastic mask",
            //     Genre = "Dark Romance",
            // };

            // // adds row to table in db
            // entityFramework.Add(aStory);
            // entityFramework.SaveChanges();

            // IEnumerable<Story>? stories = entityFramework.Story?.ToList<Story>();

            // if (stories != null)
            // {
            //     Console.WriteLine("'ID', 'TItle', 'Genre'");
            //     foreach (Story story in stories)
            //     {
            //         Console.WriteLine(
            //             "'" + story.ID + "', '" + story.Title + "', '" + story.Genre + "'"
            //         );
            //     }
            // }

            String storiesJson = File.ReadAllText("Stories.json");

            IEnumerable<Story>? storiesEnum = JsonConvert.DeserializeObject<IEnumerable<Story>>(
                storiesJson
            );

            if (storiesEnum != null)
            {
                foreach (Story astory in storiesEnum)
                {
                    Console.WriteLine(astory.Title);
                    
                    entityFramework.Add(astory);
                    entityFramework.SaveChanges();
                }
            }

            // only need
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };
            string storiesCopy = JsonConvert.SerializeObject(storiesEnum, settings);

            File.WriteAllText("storiesSerialized.txt", storiesCopy);
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
