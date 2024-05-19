using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.BL.Dto.User;
using Store.DAL.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Store.API.Controller.User
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IConfiguration _config;
		public UserController(UserManager<AppUser> userManager,IConfiguration config )
        {
			_userManager = userManager;
			_config = config;

		}
        [HttpPost("Register")]
		public async Task<IActionResult> RegisterNewUser(UserDto user)
		{
			if(ModelState.IsValid)
			{
				AppUser newUser = new AppUser()
				{
					FirstName = user.firstName,
					LastName = user.lastName,
					UserName=$"{user.firstName}{user.lastName}",
					Email = user.email,
				};

				IdentityResult reslut = await _userManager.CreateAsync(newUser, user.password);
				if(!reslut.Succeeded)
				{
					return BadRequest(reslut.Errors);
				}
				return Ok("Succed");
			}
			return BadRequest();
			
		}

		#region Login
		[HttpPost("login")]
		public async Task<IActionResult> Login(UserLoginDto user)
		{

			AppUser? result = await _userManager.FindByEmailAsync(user.email);

			if (result is null)
			{
				return BadRequest();
			}
			if (! _userManager.CheckPasswordAsync(result, user.password).GetAwaiter().GetResult())
			{
				return BadRequest();
			}
			var Myclaims = new List<Claim>();
			//claims.Add(new Claim("TokenNo", "27"));
			Myclaims.Add(new Claim(ClaimTypes.Name, result.UserName));
			Myclaims.Add(new Claim(ClaimTypes.Email, result.Email));
			Myclaims.Add(new Claim(ClaimTypes.NameIdentifier, result.Id));
			Myclaims.Add(new Claim(ClaimTypes.Role, result.Role.ToString()));
			Myclaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));


			// SigningCredentials
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecretKey"]));
			var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			//
			var token = new JwtSecurityToken(
				claims: Myclaims,
				issuer: _config["JWT:Issuer"],
				audience: _config["JWT:Audience"],
				expires: DateTime.Now.AddDays(10),
				signingCredentials: sc
				);

			var _token = new
			{
				token = new JwtSecurityTokenHandler().WriteToken(token),
				Role=result.Role.ToString(),
				expiration = token.ValidTo
			};

			return Ok( _token );
		}
		#endregion

		#region GetCurrentUser
		[Authorize]		
		[HttpGet("CurrentUser")]
		public async Task<IActionResult> GetCurrentUser()
		{
			var email = HttpContext.User.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.Email).Value;
			var User = await _userManager.FindByEmailAsync(email);
			return Ok(new 
			{
				email = User.Email,
				firstName = User.FirstName,
				lastName = User.LastName,
				Id = User.Id,
			});
		}
		#endregion
	}
}
