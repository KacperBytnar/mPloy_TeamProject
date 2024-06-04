using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mPloy_TeamProjectG5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mPloy_TeamProjectG5.Pages.Tasks
{
    public class DeleteTaskModel : PageModel
    {

        ITaskService taskService;

        [BindProperty]
        public Models.Task task { get; set; }

        public DeleteTaskModel(ITaskService service)
        {
            taskService = service;
        }
        public IActionResult OnGet(int id)
        {
            task = taskService.GetTask(id);
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            taskService.DeleteTask(id);

            return RedirectToPage("GetAllTasks");
        }
    }
}
