using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace HouseholdAccoounts
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

            builder.Services.AddCors((options) =>
            {
                // the name of the policy, the corsBuilder which allows us to define the policy
                options.AddPolicy("DevCors", (corsBuilder) =>
                {
                    // these are the ports you'll see in common front end frameworks use eg 4200 - Angular, 3000 - React, 8000 - Vue
                    corsBuilder.WithOrigins("http://localhost:4200", "http://localhost:3000", "http://localhost:8000")
                        .AllowAnyMethod() // the different verbs we send to our API (eg get, put, post, delete etc)
                        .AllowAnyHeader() // allow a user to pass us a dynamic header allows customisation by users that aren't usual
                        .AllowCredentials(); //eg a token used for authentication
                });
                options.AddPolicy("ProdCors", (corsBuilder) =>
                {
                    // use your actual site address here
                    corsBuilder.WithOrigins("https://myProductionSite.com")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });

            string? tokenKeyString = builder.Configuration.GetSection("AppSettings:TokenKey").Value;

            SymmetricSecurityKey tokenKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    tokenKeyString != null ? tokenKeyString : ""
                )
            );

            // token key creates token validation parameters to tell our application how to validate a token
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = tokenKey, // key we use to validate whether or not the token being passed to the api is a valid token
                ValidateIssuer = false, // when true, this means only one application can access the api
                ValidateIssuerSigningKey = false, // when true, this means only one application can access the api
                ValidateAudience = false // relates to cors policy
            };

            // tells the builder to use the Jwt Bearer Default authentication scheme, which is to accept an authentication header that says:
            // bearer*space*token
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = tokenValidationParameters;
                });

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

            app.UseAuthentication();

            app.UseAuthorization();
            
            app.MapControllers();

            //app.MapGet("/weatherforecast", () =>
            //{
                
            //})
            //.WithName("GetWeatherForecast");

            app.Run();
        }
        
    }
}
