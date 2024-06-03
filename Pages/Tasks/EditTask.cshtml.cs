
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mPloy_TeamProjectG5.Common;
using mPloy_TeamProjectG5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mPloy_TeamProjectG5.Pages.Tasks
{
    public class EditTaskModel : PageModel
    {
        ITaskService taskService;
        [BindProperty]
        public Models.Task task { get; set; }
        [BindProperty]
        public int UserID { get; set; }

        public EditTaskModel(ITaskService service)
        {
            taskService = service;
        }

        public void OnGet(int id)
        {
            task = taskService.GetTask(id);
            UserID = User.GetUserId();

        }

        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            taskService.UpdateTask(task, UserID);
            return RedirectToPage("/Tasks/GetAllTasks");
        }

        //OR

        //public IActionResult OnGet(int id)
        //{
        //    task = taskService.GetTask(id);
        //    if (task == null)
        //    {
        //        return null;
        //    }
        //    return Page();
        //}
        //public IActionResult OnPost(Models.Task tsk)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    task = taskService.UpdateTask(tsk);
        //    return RedirectToPage("GetAllTasks");
        //}




    }
}
