namespace Core.Domain.Auth
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName;
        public string LastName;
        public string Email;
        public string UserName;
        public string Password;
        public string Token;

        public User(int id, string firstName, string lastName, string email, string userName, string password, string token )
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = password;
            Token = token;
            Id = id;
        }

        public static User Create(int id, string firstName, string lastName, string email, string userName, string password, string token)
        {
            return new User (id,  firstName,  lastName,  email,  userName,  password, token);
        }

    }
}
