using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Core.Domain.User.Auth;
using Core.Domain.User.Persistence;
using Core.Helpers;

namespace Core.Domain.User.DomainServices
{
    public class UserServices : IUserService
    {

        
        private readonly AppSettings _appSettings;

        

        public User Authenticate(string username, string password)
        {
            try
            {
                using (var db = new UserContext())
                {
                    var _users = db.Users.ToList();

                    var user = _users.SingleOrDefault(x => x.UserName == username && x.Password == password);

                    if (user == null) return null;

                    return user.WithoutPassword();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public User Create(RegisterModelDto model)
        {
            User user = User.Create(0,model.FirstName,model.LastName,model.Email, model.UserName,model.Password, model.Role,"");

            using (var db = new UserContext())
            {
                Console.WriteLine("inserting");
                db.Add(User.Create(0, model.FirstName, model.LastName, model.Email, model.UserName, model.Password, model.Role, ""));
                db.SaveChanges();

                var all = db.Users.OrderByDescending(b=>b.UserName).ToList();
            }
            return user.WithoutPassword();
        }

    }

    public interface IUserService
    {
        User Authenticate(string username, string password);
        User Create(RegisterModelDto model);
    }
}
