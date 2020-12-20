using System.ComponentModel.DataAnnotations;

namespace BackEndBase.Application.ViewModel.Request.User
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string PasswordHash { get; set; }
    }
}