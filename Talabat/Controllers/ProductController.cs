using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Dto;
using Talabat.Errors;
using Talabat.Helpres;
using TalabatCore;
using TalabatCore.Entites;
using TalabatCore.Irepository;
using TlabatRepository;

namespace Talabat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IGenericinterface<Product> _Productrepo { get; }
        public IGenericinterface<ProductType> _Typerepo { get; }
        public IGenericinterface<ProductBrand> _brandrepo { get; }


        public IMapper _Mapper { get; }

        public ProductController(IGenericinterface<Product> productrepo,IGenericinterface<ProductType> Typerepo,IGenericinterface<ProductBrand> brandsrepo,IMapper mapper)
        {
            _Productrepo = productrepo;
            _Typerepo = Typerepo;
            _brandrepo = brandsrepo;
            _Mapper = mapper;
        }
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Pagination<productToDtos>>>> GetProducts([FromQuery]paramgetallproducts para)
        {
            //   var spec = new specificatiobrandandtye();

            var spec = new specificatiobrandandtye(para);
            spec.Includes.Add(b => b.ProductBrand);
            spec.Includes.Add(b => b.ProductType);

            var result = await _Productrepo.GetAllbyspec(spec);

            var count = new productparamandbrandtype(para);
            int getcount = await _Productrepo.getCount(count);
            var data = _Mapper.Map<IReadOnlyList<Product>, IReadOnlyList<productToDtos>>(result);
            
            return Ok(new Pagination<productToDtos>(para.indexpage,para.Pagesize,getcount, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            
            var spec = new specificatiobrandandtye(id);
            if (spec is null)
                  return NotFound(new ApiResponse(400));
                return await _Productrepo.getbyidspec(spec);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> getbrands()
        {
            var brands = await _brandrepo.GetAllAsync();
            return Ok(brands);
        }
        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> getTypes()
        {
            var Types = await _Typerepo.GetAllAsync();
            return Ok(Types);
        }

    }
}
