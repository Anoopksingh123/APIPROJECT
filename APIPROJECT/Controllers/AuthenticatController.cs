using APIPROJECT.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticatController : ControllerBase
    {
        private IConfiguration _config;

        public AuthenticatController(IConfiguration config)
        {
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken(LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string BuildToken(UserModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost]
        [Route("Authenticate")]
        private UserModel Authenticate(LoginModel login)
        {
            UserModel user = null;

            if (login.Username == "Anoop" && login.Password == "Singh")
            {
                user = new UserModel { Name = "Anoop Singh ", Email = "anoopsingh@gmail.com" };
            }
            return user;
        }

    }
}
