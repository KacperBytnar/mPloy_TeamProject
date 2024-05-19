using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using mPloy_TeamProjectG5.Models;

namespace mPloy_FinalProject_group5.ViewModels
{
    public class RegisterViewModel
    {
        public AppUser User { get; set; }
        [Required]
        [Display(Name = "Login")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "EmailAddress")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and password confirmation do not match")]
        public string ConfirmPassword { get; set; }
    }
}
