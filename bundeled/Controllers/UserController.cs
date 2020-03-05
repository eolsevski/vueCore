using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.User.Auth;
using Core.Domain.User.DomainServices;
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
        private readonly ILogger<UserController> _logger;
        private IUserService _userServices;

        public UserController(ILogger<UserController> logger
            ,IUserService userServices
            )
        {
            _userServices = userServices;
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.Password)) return Unauthorized();

            var user = _userServices.Authenticate(model.Username, model.Password);

            if (user == null) return Unauthorized();
            
            var tokenHandler = new JwtSecurityTokenHandler();

            var jwt = new JwtSecurityToken(
                /*issuer: "myissuer",
                audience: "myaudience",
                claims: claims,
                notBefore: DateTime.MinValue,*/
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes("12b6fb24-adb8-4ce5-aa49-79b265ebf256")),

                    SecurityAlgorithms.HmacSha256));
            
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
