using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using sunum2.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace sunum2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly SunumdbContext _sunumdbContext;
        public TokenController(IConfiguration configuration, SunumdbContext sunumdbContext)
        {
            _configuration = configuration;
            _sunumdbContext = sunumdbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            if (user != null && user.UserUserName != null && user.UserUserPassword != null)
            {
                var userModel = await GetUser(user.UserUserName, user.UserUserPassword);
                if (userModel != null) {
                    var claims = new[]
                    {
                        new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                        new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        //new Claim("Id",user.Id.ToString()),
                        //new Claim("UserName",user.UserUserName.ToString()),
                        //new Claim("Password",user.UserUserPassword.ToString())
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signIn
                    );

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }

        [HttpGet]
        public async Task<User> GetUser(string userName,string password)
        {
            return await _sunumdbContext.Users.FirstOrDefaultAsync(x=>x.UserUserName == userName && x.UserUserPassword == password);
        }
    }
}
