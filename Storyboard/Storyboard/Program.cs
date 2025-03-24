using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Storyboard.Data;
using Storyboard.Data.Interfaces;
using Storyboard.Models;

namespace Storyboard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Add services to the container.
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(
                (options) =>
                {
                    // the name of the policy, the corsBuilder which allows us to define the policy
                    options.AddPolicy(
                        "DevCors",
                        (corsBuilder) =>
                        {
                            // these are the ports you'll see in common front end frameworks use eg 4200 - Angular, 3000 - React, 8000 - Vue
                            corsBuilder
                                .WithOrigins(
                                    "http://localhost:4200",
                                    "http://localhost:3000",
                                    "http://localhost:8000"
                                )
                                .AllowAnyMethod() // the different verbs we send to our API (eg get, put, post, delete etc)
                                .AllowAnyHeader() // allow a user to pass us a dynamic header allows customisation by users that aren't usual
                                .AllowCredentials(); //eg a token used for authentication
                        }
                    );
                    options.AddPolicy(
                        "ProdCors",
                        (corsBuilder) =>
                        {
                            // use your actual site address here
                            corsBuilder
                                .WithOrigins("https://myProductionSite.com")
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials();
                        }
                    );
                }
            );

            builder.Services.AddScoped<IUserRepository, UserRepository>();
             builder.Services.AddScoped<IStoryRepository, StoryRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // app.MapOpenApi();
                app.UseCors("DevCors"); // select the CORS policy from the builder and apply it to the app
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseCors("ProdCors"); // select the CORS policy from the builder and apply it to the app
                app.UseHttpsRedirection();
            }

            app.MapControllers();

            //app.MapGet("/weatherforecast", () =>
            //{

            //})
            //.WithName("GetWeatherForecast");

            app.Run();
        }
    }
}

//             // applies all the specifics in the appsettings file
//             IConfiguration config = new ConfigurationBuilder()
//                 .AddJsonFile("appsettings.json")
//                 .Build();

//             DataContextEF entityFramework = new DataContextEF(config);

//             // Story aStory = new Story()
//             // {
//             //     Title = "The man in the plastic mask",
//             //     Genre = "Dark Romance",
//             // };

//             // // adds row to table in db
//             // entityFramework.Add(aStory);
//             // entityFramework.SaveChanges();

//             // IEnumerable<Story>? stories = entityFramework.Story?.ToList<Story>();

//             // if (stories != null)
//             // {
//             //     Console.WriteLine("'ID', 'TItle', 'Genre'");
//             //     foreach (Story story in stories)
//             //     {
//             //         Console.WriteLine(
//             //             "'" + story.ID + "', '" + story.Title + "', '" + story.Genre + "'"
//             //         );
//             //     }
//             // }

//             String storiesJson = File.ReadAllText("Stories.json");

//             IEnumerable<Story>? storiesEnum = JsonConvert.DeserializeObject<IEnumerable<Story>>(
//                 storiesJson
//             );

//             if (storiesEnum != null)
//             {
//                 foreach (Story astory in storiesEnum)
//                 {
//                     Console.WriteLine(astory.Title);

//                     entityFramework.Add(astory);
//                     entityFramework.SaveChanges();
//                 }
//             }

//             // only need
//             JsonSerializerSettings settings = new JsonSerializerSettings()
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver(),
//             };
//             string storiesCopy = JsonConvert.SerializeObject(storiesEnum, settings);

//             File.WriteAllText("storiesSerialized.txt", storiesCopy);
//         }
//     }
// }

// var builder = WebApplication.CreateBuilder(args);

// // // Add services to the container.
// // // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// // builder.Services.AddOpenApi();

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddControllers();
//  var app = builder.Build();

// // // Configure the HTTP request pipeline.
//  if (app.Environment.IsDevelopment())
//  {
//      app.UseSwagger();
//      app.UseSwaggerUI();
//  }

// // app.UseHttpsRedirection();

// // var summaries = new[]
// // {
// //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// // };

// // app.MapGet("/weatherforecast", () =>
// // {
// //     var forecast =  Enumerable.Range(1, 5).Select(index =>
// //         new WeatherForecast
// //         (
// //             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
// //             Random.Shared.Next(-20, 55),
// //             summaries[Random.Shared.Next(summaries.Length)]
// //         ))
// //         .ToArray();
// //     return forecast;
// // })
// // .WithName("GetWeatherForecast");

// // app.Run();

// // record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// // {
// //     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// // }
