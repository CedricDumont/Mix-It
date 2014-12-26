using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MixIt.WebApi.Models
{
    public class RegisterInputModel
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}