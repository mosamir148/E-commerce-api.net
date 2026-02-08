using Microsoft.AspNetCore.Mvc;
using Talabat.Helpres;
using TalabatCore.Irepository;
using TlabatRepository.Data;
using TlabatRepository;
using Talabat.Errors;
using Microsoft.EntityFrameworkCore;

namespace Talabat.Extention
{
    public static class ApplicationservisesExtenion
    {
        public static void AddAplicationServises(this IServiceCollection services)
        {
           

          
            services.AddScoped(typeof(IGenericinterface<>), typeof(GenericRepository<>));

            services.AddScoped(typeof(IBasketRepository), typeof(BasketReposetory));

            services.AddAutoMapper(typeof(MppingProfile));
          
            #region 
            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState.Where(p => p.Value.Errors.Count() > 0)
                 .SelectMany(p => p.Value.Errors)
                 .Select(e => e.ErrorMessage)
                 .ToArray();

                    var validation = new apivlaidationerrors()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(validation);
                };
            });
            #endregion
        }

    }
}
