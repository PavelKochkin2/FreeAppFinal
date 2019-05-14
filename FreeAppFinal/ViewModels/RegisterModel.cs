using System.ComponentModel.DataAnnotations;

namespace FreeAppFinal.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Please set Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please set Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}