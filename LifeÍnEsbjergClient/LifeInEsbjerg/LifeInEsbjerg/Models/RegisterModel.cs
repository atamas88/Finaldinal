using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LifeInEsbjerg.Models
{
    public class RegisterModel
    {
        [Required, DataType(DataType.EmailAddress), MaxLength(256), Display(Name = "Email address")]
        public string Email { get; set; }

        //[MaxLength(128), Display(Name = "First name")]
        //public string FirstName { get; set; }

        //[MaxLength(128), Display(Name = "Last name")]
        //public string LastName { get; set; }

        [Required, MaxLength(100), MinLength(6)]
        public string Password { get; set; }

        [Required, Compare("Password"), Display(Name = "Password (again)")]
        public string ConfirmPassword { get; set; }

        public string Roles { get; set; }


    }
}