using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Domain.User;

namespace Core.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user)
        {
            //ASAP finish it
            //user.Password = null;
            return user.GetUserWithNulledPassword();
        }
    }
}
