using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoList.Application;
using TodoList.Persistence;

namespace TodoList.WebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                //try
                //{
                    var context = scope.ServiceProvider.GetRequiredService<TodoListDbContext>();
                    context.Database.Migrate();
                    //}
                    //catch (Exception err)
                    //{
                    // TDOO: Add Logging
                    //Console.WriteLine(err.Message);
                    //}
            }
                
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    var environmentName = context.HostingEnvironment.EnvironmentName;
                    builder.AddJsonFile("appsettings.json", false, true);
                    builder.AddJsonFile($"appsettings.{environmentName}.json", true, true);

                    if (context.HostingEnvironment.IsDevelopment())
                    {
                        builder.AddJsonFile("appsettings.Local.json", true, true);
                    }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
