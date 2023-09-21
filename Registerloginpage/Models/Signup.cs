using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Registerloginpage.Models
{
    public class Signup
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string FirstName { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string LastName { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [Display(Name ="email address")]
        [Key]
        public string Email { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [Compare("ConfirmPassword",ErrorMessage ="Password does not match")]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
       
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
