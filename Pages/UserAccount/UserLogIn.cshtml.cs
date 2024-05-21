using System.Security.Claims;
using mPloy_TeamProjectG5.Models;
using mPloy_TeamProjectG5.Services.Interfaces;
using mPloy_TeamProjectG5.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mPloy_TeamProjectG5.Pages.UserAccount
{
    public class AccountLogInModel : PageModel
    {
        [BindProperty]
        public LoginViewModel loginModel { get; set; }
        public string LoginMessage = "";

        //private IUserService userService;
        private readonly SignInManager<AppUser> signInManager;
        //private IUserService userService;
        public string URL { get; set; }

        public AccountLogInModel(SignInManager<AppUser> signInManager, IUserService userService)
        {
            this.signInManager = signInManager;
            //this.userService = userService;
        }

        public void OnGet(string ReturnURL)
        {
            URL = ReturnURL;
        }

        public async Task<IActionResult> OnPost(string ReturnURL)
        {
            try
            {
                var result = await signInManager.PasswordSignInAsync(loginModel.Username, loginModel.Password, loginModel.RememberMe, false);
                if (result.Succeeded)
                {
                    Claim claim1 = new Claim(ClaimTypes.Name, loginModel.Username);
                    Claim claim2 = new Claim(ClaimTypes.Role, "AppUser");

                    List<Claim> Claims = new List<Claim>() { claim1, claim2 };

                    ClaimsIdentity identity = new ClaimsIdentity(Claims, "CookiesUserAuth");

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    //var userID = this.userService.getuser
                    await HttpContext.SignInAsync("CookiesUserAuth", claimsPrincipal);
                    if (ReturnURL != null)
                    {
                        return RedirectToPage(ReturnURL);
                    }
                    else return RedirectToPage("/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Wrong username or password. Please try again.");
                    //LoginMessage = "Wrong username or password. Please try again.";
                    return Page();
                }
            }
            catch (Exception e)
            {
                LoginMessage = e.Message;
                return Page();
            }
        }
    }
}
