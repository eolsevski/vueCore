using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Core.Domain.User.Auth;
using Core.Helpers;

namespace Core.Domain.User.DomainServices
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
            
            return user.WithoutPassword();
        }

        public User Create(RegisterModelDto model)
        {
            User user = User.Create(2,model.FirstName,model.SecondName,model.Email, model.UserName,model.Password,"");

            _users.Add(user);

            return user.WithoutPassword();
        }

    }

    public interface IUserService
    {
        Domain.User.User Authenticate(string username, string password);
        User Create(RegisterModelDto model);
    }
}
