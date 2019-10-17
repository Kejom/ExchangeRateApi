namespace ExchangeRateCalculatorWebApi.Models
{
    using ExchangeRateCalculatorWebApi.Controllers;
    using SQLite.CodeFirst;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LogContext : DbContext
    {
        public DbSet<CallToApiLog> CallsToApi { get; set; }
        public DbSet<CallToExternalResourceLog> CallsToExternalResources { get; set; }


        public LogContext()
            : base("name=MyDB")
          
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<LogContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
            
        }


    }

}