using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Doctors.Models;
using MyAPI.Services.User_Login_Request;
using Microsoft.AspNetCore.Authorization;

namespace Doctors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginRequest userLoginRequest)
        {
            try
            {
                if (await IsValidUserAsync(userLoginRequest.UserName, userLoginRequest.Password))
                {
                    var token = GenerateJwtToken(userLoginRequest.UserName);
                    return Ok(new { Token = token });
                }

                return Unauthorized(new { Message = "Invalid credentials" });
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }

        private async Task<bool> IsValidUserAsync(string userName, string password)
        {
            // Implement actual user validation logic, e.g., check against the database
            // Use secure password hashing mechanisms
            return userName == "admin" && password == "123";
        }

        private string GenerateJwtToken(string userName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, userName),
            // Add additional claims as needed
        };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpirationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
