using System.ComponentModel.DataAnnotations;

namespace AspNetWebApi.Models
{


    public class Register
    {
        [Required (ErrorMessage = "User Name is required")]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set;}

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password")]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}