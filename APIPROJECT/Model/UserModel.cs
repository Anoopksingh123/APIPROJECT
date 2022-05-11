using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIPROJECT.Model
{
    public class UserModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }
    }
}
