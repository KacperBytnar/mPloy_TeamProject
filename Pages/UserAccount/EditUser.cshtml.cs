using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using mPloy_TeamProjectG5.Common;
using mPloy_TeamProjectG5.Models;
using mPloy_TeamProjectG5.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mPloy_TeamProjectG5.Pages.UserAccount
{
     public class EditUserModel : PageModel
    {
        [BindProperty]
        public AppUser LoggedUser { get; set; }
        private IUserService userService;
        [BindProperty(SupportsGet = true)]
        public int UserID { get; set; }
        [BindProperty]
        public IFormFile? Upload { get; set; } 
        // path for the Images folder
        //private string ImagePath
        //{
        //    get { return Path.Combine(WebHostEnvironment.WebRootPath, "Images/Avatars"); }
        //}
        //public IWebHostEnvironment WebHostEnvironment { get; } //Property
        public EditUserModel(IUserService userService)
        {
            this.userService = userService;

        }
        public void OnGet()
        {
            UserID = User.GetUserId();
            LoggedUser = userService.GetUserById(UserID);
            LoggedUser.Id = UserID;
            if (!string.IsNullOrEmpty(LoggedUser.Picture))
            {
                LoggedUser.Picture = "/Images/Avatars/" + LoggedUser.Picture;
            }
            else
            {
                LoggedUser.Picture = "/Images/Avatars/DefaultAvatar.png";

            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //if (Upload.FileName != null)
            //{
            //    var file = Path.Combine(_environment.ContentRootPath, ImagePath, Upload.FileName);
            //    using (var fileStream = new FileStream(file, FileMode.Create))
            //    {
            //        Upload.CopyTo(fileStream);
            //    }
            //    LoggedUser.Picture = Upload.FileName;


            //    userService.EditUser(LoggedUser);
            //    return RedirectToPage("/UserAccount/DisplayUser");
            //}
            else
            {
                if (UserID == 0)
                {
                    UserID = User.GetUserId();
                }
                LoggedUser.Id = UserID;
                userService.EditUser(LoggedUser);
                return RedirectToPage("/UserAccount/DisplayUser");
            }
            
        }
    }
}