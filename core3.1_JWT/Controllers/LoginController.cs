using core3._1_JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace core3._1_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private List<UserModel> UserModelList = new List<UserModel>();
        public LoginController(IConfiguration config)
        {
            _config = config;
            UserModelList.Add(new UserModel()
            {
                UserId = 1,
                UserName = "A",
                Password = "A",
                Email = "A",
            });
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var userModel = UserModelList.Where(m => m.UserName == userLogin.UserName).FirstOrDefault();
            if (userModel != null)
            {
                var token = Generate(userModel);
                return Ok(token);
            }
            else
            {
                return NotFound("NotFound");
            }
        }

        private string Generate(UserModel userModel)
        {
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credential = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier,userModel.UserName),
            new Claim(ClaimTypes.Email,userModel.Email),
            };
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddSeconds(10),
                signingCredentials: credential
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
