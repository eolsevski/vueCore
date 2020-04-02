using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.User
{
    public class UserProperties
    {
        public int Id { get; private set; }
        public User UserId { get; private set; }
        public string PathToUploads { get; private set; }
     
        
        //ASAP remove this line github: vdasus
    }
}
