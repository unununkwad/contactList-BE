using contactList_BE.Data;
using contactList_BE.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace contactList_BE.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly DbCon db;
		private readonly IConfiguration _config;
		public AuthController(IConfiguration config, DbCon db)
		{
			_config = config;
			this.db = db;
		}

		[HttpPost]
		public async Task<IActionResult> Login(User login)
		{
			// check login data and return token
			User? user = await db.User.Where(a => a.UserName == login.UserName).FirstOrDefaultAsync();
			if (user != null && BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
			{
				var token = GenerateJwtToken(login.UserName);
				return Ok(new { Token = token, UserName = login.UserName });
			}
			return Unauthorized();
		}

		// generate token from username for 8 hours
		private string GenerateJwtToken(string username)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, username),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			var token = new JwtSecurityToken(
				issuer: _config["Jwt:Issuer"],
				audience: _config["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(480),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}




