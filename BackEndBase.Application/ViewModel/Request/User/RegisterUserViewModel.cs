using System;
using System.ComponentModel.DataAnnotations;

namespace BackEndBase.Application.ViewModel.Request.User;

public class RegisterUserViewModel
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    [Phone]
    public string Phone { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string PasswordHash { get; set; }
}