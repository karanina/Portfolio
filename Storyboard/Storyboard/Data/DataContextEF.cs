// this file is for the Dapper version of database queries
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Storyboard.Models;

namespace Storyboard.Data
{
    public class DataContextEF : DbContext
    {
        private IConfiguration _config;

        public DataContextEF(IConfiguration config)
        {
            _config = config;
        }

        public virtual DbSet<Story> Stories { get; set; }
        public virtual DbSet<User> Users { get; set; }

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

            modelBuilder
                .Entity<Story>()
                .ToTable("Story")
                // specifies the primary key - needed to work
                .HasKey(s => s.Id);
            modelBuilder
                .Entity<User>()
                // alternatively .ToTable("tableName", "schemaName")
                .ToTable("Users")
                .HasKey(u => u.UserId);
        }
    }
}
