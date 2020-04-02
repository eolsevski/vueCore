using Core.Domain.FileService;
using Core.Domain.User.Auth;
using Core.Domain.User.DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace bundeled.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserService _userServices;
        private IFileService _fileService;

        public UserController(ILogger<UserController> logger, IUserService userServices, IFileService fileService)
        {
            _userServices = userServices;
            _logger = logger;
            _fileService = fileService;
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

        [HttpPost("register")]
        public IActionResult RegisterNewUser([FromBody] RegisterModelDto model)
        {
            _userServices.Create(model);

            return Ok("registered");
        }

        [Authorize]
        [HttpPost("checkToken")]
        public IActionResult CheckToken()
        {
            return Ok();
        }

    }
}
