using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityLibrary.Models
{
    public class UserCreateVM
    {
        //Qeydiyyatdan keçerken input alacağımız deyerler
        [Required(ErrorMessage ="Username cannot be empty!")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Email adress cannot be empty!")]
        [EmailAddress(ErrorMessage ="Email adress is invalid!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password cannot be empty!")]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password",ErrorMessage ="Password is incorrect!")]
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
    }
}
