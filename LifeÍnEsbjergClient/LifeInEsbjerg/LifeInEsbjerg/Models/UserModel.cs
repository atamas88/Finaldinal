using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeInEsbjerg.Models
{
    public class UserModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Roles { get; set; }
        public string Token { get; set; }
    }
}