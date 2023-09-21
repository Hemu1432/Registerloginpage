using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace Registerloginpage.Models
{
    public class Applicationuser:IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

    }
}
