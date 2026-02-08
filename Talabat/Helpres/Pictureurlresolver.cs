using AutoMapper;
using Talabat.Dto;
using TalabatCore.Entites;

namespace Talabat.Helpres
{
    public class Pictureurlresolver : IValueResolver<Product, productToDtos, string>
    {
        private readonly IConfiguration _configuration;

        public Pictureurlresolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, productToDtos destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{_configuration["BaseApi"]}{source.PictureUrl}";
            return string.Empty;
        }
    }
}
