using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using mPloy_TeamProjectG5.Models;
using mPloy_TeamProjectG5.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mPloy_TeamProjectG5.Pages.UserAccount
{
    public class CreateUserModel : PageModel
    {
        [BindProperty]
        public RegisterViewModel registerModel { get; set; }
        public string registerMessage { get; set; }


        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public CreateUserModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (registerModel.Password != registerModel.ConfirmPassword)
            {
                registerMessage = "Passwords are different!";
                return Page();
            }
            else if (registerModel.Password == null)
            {
                registerMessage = "Password can't be empty!";
                return Page();
            }
            else
            {
                var userr = new AppUser()
                {
                    Email = registerModel.User.Email,
                    UserName = registerModel.Username,
                    Description = registerModel.User.Description,
                    FirstName = registerModel.User.FirstName,
                    LastName = registerModel.User
                .LastName,
                    Age = registerModel.User.Age,
                    StreetAddress = registerModel.User.StreetAddress,
                    ZipCode = registerModel.User
                .ZipCode,
                    City = registerModel.User
                .City,
                    PhoneNumber = registerModel.User
                .PhoneNumber
                };
                var result = await userManager.CreateAsync(userr, registerModel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(userr, isPersistent: false);
                    return RedirectToPage("/UserAccount/DisplayUser");
                }
                else
                {
                    foreach (var er in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, er.Description);
                        registerMessage = er.Description;
                    }
                    return Page();
                }
            }
        }
    }
}


