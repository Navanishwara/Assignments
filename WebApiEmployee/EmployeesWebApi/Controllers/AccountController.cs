using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmployeesWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EmployeesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IConfiguration _config;


       [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserDetails user)
        {
           

            if (user.username == "admin" && user.password == "admin")
            {
                //generate token
                var secretkey = _config["jwt:secretKey"];
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey));
                var tokenparams = new JwtSecurityToken
                (
                   issuer: _config["jwt:issuer"],
                   audience: _config["jwt:audience"],
                   expires: DateTime.Now.AddMinutes(2),
                   signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
                   claims:new List<Claim>
                   {
                       new Claim(ClaimTypes.Role,"Admin")
                   }
                );
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.WriteToken(tokenparams);
                return Ok(token);
            }
            else
            {
                return BadRequest("invalid user credintials");
            }

        }

    }
}