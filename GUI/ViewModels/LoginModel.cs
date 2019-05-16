using System.ComponentModel.DataAnnotations;

//namespace FreeAppFinal.ViewModels
namespace GUI.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please set Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please set Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}