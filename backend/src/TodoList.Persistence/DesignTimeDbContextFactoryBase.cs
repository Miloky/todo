using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TodoList.Persistence
{
    public abstract class DesignTimeDbContextFactoryBase<TContext>: IDesignTimeDbContextFactory<TContext> where TContext: DbContext
    {
        public TContext CreateDbContext(string[] args)
        {
            string basePath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "/TodoList.WebHost";
            Console.WriteLine(basePath);
            var environmentName = Environment.GetEnvironmentVariable(PersistenceConfiguration.AspNetCoreEnvironment);
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", false, false)
                .AddJsonFile($"appsettings.{environmentName}.json", true, false)
                .AddJsonFile("appsettings.Local.json", true, false)
                .AddEnvironmentVariables()
                .Build();
            
            var connectionString = configuration.GetConnectionString(PersistenceConfiguration.ConnectionStringName);
            Console.WriteLine(connectionString);
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseMySql(connectionString);
            return  CreateNewInstance(optionsBuilder.Options);
        }

        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);
    }
}