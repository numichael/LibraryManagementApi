using System.ComponentModel.DataAnnotations;

namespace AspNetWebApi.Models
{


    public class Login
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}