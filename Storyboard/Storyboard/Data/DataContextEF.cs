// this file is for the Dapper version of database queries
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Storyboard.Models;
using Microsoft.Extensions.Configuration;

namespace Storyboard.Data
{
    public class DataContextEF : DbContext
    {
        private IConfiguration _config;

        public DataContextEF(IConfiguration config){
            _config = config;
        }
        public DbSet<Story>? Story { get; set; }

        // called when DataContextEF (DbContext) is created, gives access to the connection string
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                // Integrated Security = true as I'm using Windows Authentication for the db
                // TrustServerCertificate=True as I'm using a local db
                // @ creates a verbatim string - treats the \ as a literal character ie not an escape character
                // checks if options have been configured, and if not tries and retries on failure
                // checks the default schema (dbo), if using a named schema specify it in the OnModelCreating method
                options.UseSqlServer(
                   _config.GetConnectionString("DefaultConnection"),
                    options => options.EnableRetryOnFailure()
                );
            }
        }

        // maps the model to a table in sql server
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            // table name in SQL server
            // specifies the primary key - needed to wrok
            modelBuilder.Entity<Story>().ToTable("Story").HasKey(s => s.ID);
            // alternatively .ToTable("tableName", "schemaName")
        }
    }
}
