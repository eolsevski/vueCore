﻿using Core.Domain.Auth;
using Core.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace Core.Domain.DomainServices
{
    public class UserServices : IUserService
    {

        private List<User> _users = new List<User> { User.Create(1, "firstName", "lastName", "example@example.com", "userName", "password", "")
        };
        private readonly AppSettings _appSettings;

        public UserServices()
        {
        }

        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.UserName == username && x.Password == password);

            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes("12b6fb24-adb8-4ce5-aa49-79b265ebf256");

            var jwt = new JwtSecurityToken(
            /*issuer: "myissuer",
            audience: "myaudience",
            claims: claims,
            notBefore: DateTime.MinValue,*/
            expires: DateTime.Now.AddMinutes(1),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256));

            user.Token = tokenHandler.WriteToken(jwt);

            return user.WithoutPassword();
        }

    }

    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
