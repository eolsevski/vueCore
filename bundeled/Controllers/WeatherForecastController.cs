using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace bundeled.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            /*var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123")), SecurityAlgorithms.HmacSha512Signature),
            };*/

            /*var claims = new[]
            {
                new Claim(ClaimTypes.Role, "Grandpa"),
            };*/

            var jwt = new JwtSecurityToken(
                /*issuer: "myissuer",
                audience: "myaudience",
                claims: claims,
                notBefore: DateTime.MinValue,
                expires: DateTime.Now.AddHours(1),*/
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("12b6fb24-adb8-4ce5-aa49-79b265ebf256")), SecurityAlgorithms.HmacSha256));

            return Ok( tokenHandler.WriteToken(jwt));
        }
        [Authorize]
        [HttpPost("secret")]
        public IActionResult Secret()
        {
            return Ok("Top secret page");
        }


    }
}
