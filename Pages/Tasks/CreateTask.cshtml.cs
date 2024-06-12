using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mPloy_TeamProjectG5.Common;
using mPloy_TeamProjectG5.Models;
using mPloy_TeamProjectG5.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mPloy_TeamProjectG5.Pages.Tasks
{
    [Authorize]
    public class CreateTaskModel : PageModel
    {
        IUserService userService;
        ITaskService taskService; 
        [BindProperty]
        public Models.Task task { get; set; }
        public int UserID { get; set; }

        public CreateTaskModel(ITaskService tService, IUserService userService)
        {
            taskService = tService;
            //AppUser taskCreator = new AppUser ();
            //taskCreator = userService.GetUserById(UserID);

            //task.Creator= taskCreator;

            this.userService = userService;
        }

        public IActionResult OnGet()
        {
            UserID = User.GetUserId();
            return Page();
        }
        public IActionResult OnPost(int UserID)
        {
            //if (!ModelState.IsValid)
            //{
            //    foreach (var modelStateKey in ModelState.Keys)
            //    {
            //        var value = ModelState[modelStateKey];
            //        foreach (var error in value.Errors)
            //        {
            //            // Log the errors (You can replace this with proper logging)
            //            Console.WriteLine($"Key: {modelStateKey}, Error: {error.ErrorMessage}");
            //        }
            //    }
            //    return Page();
            //}
            taskService.CreateTask(task, UserID);
            return RedirectToPage("GetAllTasks");
        }
    }
}
