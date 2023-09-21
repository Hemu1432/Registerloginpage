using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Registerloginpage.Models
{
    public class ChangePassword
    {
        [Key]
        [System.ComponentModel.DataAnnotations.Required, DataType(DataType.Password)]
        public string currentpassword { get; set; }
        [System.ComponentModel.DataAnnotations.Required, DataType(DataType.Password)]
        public string Newpassword { get; set; }
        [System.ComponentModel.DataAnnotations.Required, DataType(DataType.Password)]
        [Compare("Newpassword",ErrorMessage="Confirm new password does not match")]
        public string ConfirmNewpassword { get; set; }


    }
}
