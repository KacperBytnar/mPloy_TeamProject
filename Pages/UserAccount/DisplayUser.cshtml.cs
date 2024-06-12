using mPloy_TeamProjectG5.Models;
using mPloy_TeamProjectG5.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mPloy_TeamProjectG5.Common;

namespace mPloy_TeamProjectG5.Pages.UserAccount
{
    [Authorize]
    public class DisplayUserModel : PageModel
    {
        [BindProperty]
        public AppUser LoggedUser { get; set; }

        private IUserService userService;
        [BindProperty]
        public int UserID { get; set; }
        public DisplayUserModel(IUserService service)
        {
            userService = service;
        }

        public void OnGet()
        {
            UserID = User.GetUserId();
            LoggedUser = userService.GetUserById(UserID);
            if (!string.IsNullOrEmpty(LoggedUser.Picture))
            {
                LoggedUser.Picture = "/Images/Avatars/" + LoggedUser.Picture;
            }
            else
            {
                LoggedUser.Picture = "/Images/Avatars/DefaultAvatar.png";

            }
        }
    }
}
