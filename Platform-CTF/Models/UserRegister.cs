using System.ComponentModel.DataAnnotations;

namespace Platform_CTF.Models
{
    public class UserRegister
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required] [Display(Name = "Email")] public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}