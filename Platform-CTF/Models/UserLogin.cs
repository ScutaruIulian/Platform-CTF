using System.ComponentModel.DataAnnotations;

namespace Platform_CTF.Models
{
    public class UserLogin
    {
        [Required]
        [Display(Name = "Username or Email")]
        public string Credentials { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}