using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Talabat.Dto;
using Talabat.Errors;
using Talabat.Extention;
using TalabatCore.Entites;
using TalabatCore.Servise;

namespace Talabat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenservise _tokenservise;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager
            ,SignInManager<AppUser> signInManager,
            ITokenservise tokenservise,
            IMapper mapper
           )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._tokenservise = tokenservise;
            this._mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto Model)
        {
           
           var user = await _userManager.FindByEmailAsync(Model.Email);
            if (user == null) 
                return Unauthorized(new ApiResponse(401));
            var result = await _signInManager.CheckPasswordSignInAsync(user, Model.Password, false);

            return Ok(new UserDto()
            {
                Name = user.DisplayName,
                Email = user.Email,
                Token = await _tokenservise.Createtoken(user,_userManager)

            }); ;

        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto model)
        {
            if (CheckEmailExist(model.Email).Result.Value)
                return BadRequest(400);
            var user = new AppUser()
            {
                DisplayName = model.Name,
                Email = model.Email,
                UserName = model.Email.Split('@')[0],
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return BadRequest(new ApiResponse(400));
            return Ok(new UserDto()
            {
                Name = user.DisplayName,
                Email = model.Email,
                Token = await _tokenservise.Createtoken(user, _userManager)
            });
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("getUser")]
         public async Task<ActionResult<UserDto>> getUser()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(Email);
            return Ok(new UserDto()
            {
                Name = user.DisplayName,
                Email = user.Email,
                Token = await _tokenservise.Createtoken(user, _userManager)
            });
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetUserAddress")]
        public async Task<ActionResult<UserDto>> getuseradress()
        {
            var user = await _userManager.getuserwhithadressasync(User);
            var adresdto =  _mapper.Map<Address, AdressDto>(user.address);
            return Ok(adresdto);
        }



        [Authorize]
        [HttpPut("Updateadress")]
        public async Task<ActionResult<AdressDto>> updateadress(AdressDto dto)
        {
            var Adddress = _mapper.Map<AdressDto,Address>(dto);

            var user = await _userManager.getuserwhithadressasync(User);

          

           Adddress.id = user.address.id;

            user.address = Adddress;

            var result = await _userManager.UpdateAsync(user);
            if(!result.Succeeded) return BadRequest(new ApiResponse(400));
            return Ok(dto);

        }

        [HttpGet("emailExist")]
        public async Task<ActionResult<bool>> CheckEmailExist(string Email)
        {
            return await _userManager.FindByEmailAsync(Email) is not null;
        }
        
    }
}
