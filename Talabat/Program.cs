using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using Talabat.Errors;
using Talabat.Extention;
using Talabat.Helpres;
using TalabatCore.Irepository;
using TlabatRepository;
using TlabatRepository.Data;

namespace Talabat
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            builder.Services.AddSwagerCollectio();
            // Add services to the container.
            builder.Services.AddDbContext<StoreContext>(option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("Defaultconection")));


            builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var connect = builder.Configuration.GetConnectionString("Redis");
                return ConnectionMultiplexer.Connect(connect);
            });
            
              

            builder.Services.AddAplicationServises();

            var app = builder.Build();

           using var scop = app.Services.CreateScope();

            var serv = scop.ServiceProvider;

            var logger = serv.GetRequiredService<ILoggerFactory>();



            try
            {
                var dbcontxt = serv.GetRequiredService<StoreContext>();

                await dbcontxt.Database.MigrateAsync();

               await storecontextseed.seedasync(dbcontxt);
            } catch (Exception ex)
            {
              var logg =  logger.CreateLogger<Program>();
                logg.LogError(ex, "handle the exception");
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.AddSwagerUi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}