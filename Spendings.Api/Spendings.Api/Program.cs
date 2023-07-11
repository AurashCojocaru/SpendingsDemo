using Microsoft.EntityFrameworkCore;
using Spendings.DataAccess;
using Spendings.Logic;
using System;
using System.Reflection;

namespace Spendings.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
           
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString(nameof(AppDbContext)),
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30), null);
                        sqlOptions.MigrationsAssembly(typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name);
                    }), ServiceLifetime.Transient);

            builder.Services.AddTransient<ITransactionsRepo, TransactionsRepo>();

            builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<Program>());
            
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}