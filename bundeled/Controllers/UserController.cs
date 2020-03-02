using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Auth;
using Core.Domain.DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace bundeled.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UserController> _logger;
        private IUserService _userServices;

        public UserController(ILogger<UserController> logger
            ,IUserService userServices
            )
        {
            _userServices = userServices;
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
        public IActionResult Login([FromBody] AuthenticateModel model)
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
                notBefore: DateTime.MinValue,*/
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes("12b6fb24-adb8-4ce5-aa49-79b265ebf256")),

                    SecurityAlgorithms.HmacSha256));
            
             var user = _userServices.Authenticate(model.Username, model.Password);
            
            if (user == null) return Unauthorized();

            user.Token = tokenHandler.WriteToken(jwt);

            return Ok(new { token = user.Token });
        }
        [Authorize]
        [HttpPost("secret")]
        public IActionResult Secret()
        {
            return Ok("Top secret info");
        }
        [HttpPost("upload")]
        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();
                    Console.WriteLine(filePath);
                    await using var stream = System.IO.File.Create(filePath);
                    await formFile.CopyToAsync(stream);
                }
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size });
        }


    }
}
