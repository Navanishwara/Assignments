using System.IdentityModel.Tokens.Jwt;
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
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserDetails user)
        {

            if (user.username == "admin" && user.password == "admin")
            {
                //generate token
                var secretkey = "abcdefghijklmnopqrstuvwxyz1234567";
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey));
                var tokenparams = new JwtSecurityToken
                (
                   issuer: "tavant",
                   audience: "tavant",
                   expires: DateTime.Now.AddMinutes(2),
                   signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
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