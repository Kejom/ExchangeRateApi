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
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<LogContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
            
        }


    }

}