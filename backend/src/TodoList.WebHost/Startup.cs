using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoList.Application;
using TodoList.Persistence;

namespace TodoList.WebHost
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoListDbContext>(options =>
            {
                var connectionString =
                    _configuration.GetConnectionString(PersistenceConfiguration.ConnectionStringName);

                if (String.IsNullOrWhiteSpace(connectionString))
                {
                    throw new ArgumentOutOfRangeException(
                        $"Connection string ({PersistenceConfiguration.ConnectionStringName}:${connectionString}) cannot be empty!");
                }

                Console.WriteLine(connectionString);
                options.UseMySql(connectionString);
            });

            services.AddScoped<ITodoListDbContext>(provider => provider.GetService<TodoListDbContext>());
            services.AddControllers();
            services.AddPersistence(_configuration);
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();


            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
