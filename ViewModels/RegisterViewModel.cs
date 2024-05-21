using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using mPloy_TeamProjectG5.Models;

namespace mPloy_TeamProjectG5.ViewModels
{
    public class RegisterViewModel
    {
        public required AppUser User { get; set; }
        [Required]
        [Display(Name = "Login")]
        public required string Username { get; set; }

        [Required]
        [Display(Name = "EmailAddress")]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and password confirmation do not match")]
        public required string ConfirmPassword { get; set; }
    }
}
