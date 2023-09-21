using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Registerloginpage.Models
{
    public class Login
    {
        [Key]
        [System.ComponentModel.DataAnnotations.Required,EmailAddress]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get;set; }
    }
}
