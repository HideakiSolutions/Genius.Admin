using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        [EmailAddress]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
    }
}
