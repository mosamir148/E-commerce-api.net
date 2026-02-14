using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using Talabat.Errors;
using Talabat.Extention;
using Talabat.Helpres;
using TalabatCore.Entites;
using TalabatCore.Irepository;
using TalabatCore.Servise;
using TalabatServise;
using TlabatRepository;
using TlabatRepository.Data;
using TlabatRepository.identitymi;

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

            builder.Services.AddDbContext<AppIdentityDbcontext>(option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("Identityconnection")));

            builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var connect = builder.Configuration.GetConnectionString("Redis");
                return ConnectionMultiplexer.Connect(connect);
            });


        
            builder.Services.AddAplicationServises();

            builder.Services.identityservuse();

            var app = builder.Build();

           using var scop = app.Services.CreateScope();

            var serv = scop.ServiceProvider;

            var logger = serv.GetRequiredService<ILoggerFactory>();



            try
            {
                var dbcontxt = serv.GetRequiredService<StoreContext>();

                await dbcontxt.Database.MigrateAsync();

                var identity = serv.GetRequiredService<AppIdentityDbcontext>();
                await identity.Database.MigrateAsync();

                var user = serv.GetRequiredService<UserManager<AppUser>>();
               await AppidentitySeed.seeduserasync(user);
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