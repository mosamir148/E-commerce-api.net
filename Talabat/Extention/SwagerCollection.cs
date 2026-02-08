using System.Runtime.CompilerServices;

namespace Talabat.Extention
{
    public static class SwagerCollection
    {
        public static IServiceCollection AddSwagerCollectio(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }


        public static WebApplication AddSwagerUi(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
