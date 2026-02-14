using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Talabat.Dto;
using Talabat.Errors;
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

        public AccountController(UserManager<AppUser> userManager
            ,SignInManager<AppUser> signInManager,
            ITokenservise tokenservise
           )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._tokenservise = tokenservise;
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

               

        
    }
}
