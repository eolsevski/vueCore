using System.Threading;

namespace Core.Domain.User
{
    public class User
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public string Token { get; set; }

        public User(int id, string firstName, string lastName, string email, string userName, string password,string role, string token )
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = password;
            Role = role;
            Token = token;
            Id = id;
        }

        public void SetPasswordYoNull()
        {
            this.Password = null;
        }

        public User GetUserWithNulledPassword()
        {
            /*var result = new User(Id, FirstName, LastName, Email, UserName, null, Role, Token);
            this.Password = null;
            return this;*/
            return new User(Id, FirstName, LastName, Email, UserName, null, Role, Token);
        }

        public static User Create(int id, string firstName, string lastName, string email, string userName, string password, string role, string token)
        {
            return new User (id,  firstName,  lastName,  email,  userName,  password, role, token);
        }

    }
}
