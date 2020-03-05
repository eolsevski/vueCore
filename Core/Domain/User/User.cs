namespace Core.Domain.User
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName;
        public string LastName;
        public string Email;
        public readonly string UserName;
        public string Password;
        //public string Role;
        public string Token;

        private User(int id, string firstName, string lastName, string email, string userName, string password, string token )
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
