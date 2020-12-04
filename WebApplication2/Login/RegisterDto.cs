using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YogaStudio.Login
{
    public class RegisterDto
    {
        [Required]
        public  string Username { get; set; }
  
       [Required]
        public string  Password { get; set; }
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
