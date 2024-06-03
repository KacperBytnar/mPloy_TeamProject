using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mPloy_TeamProjectG5.Common;
using mPloy_TeamProjectG5.Models;
using mPloy_TeamProjectG5.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mPloy_TeamProjectG5.Pages.Tasks
{
    [Authorize]
    public class GetAllTasksModel : PageModel
    {
        private ITaskService taskService;
        public IBidService bidService;

        [BindProperty]
        public IEnumerable<Models.Task> tasks { get; set; }

        public string text { get; set; } = "Nobody has applied for the task yet!";

        // Criteria for category filtering
        [BindProperty(SupportsGet = true)]
        public string Criteria { get; set; }


        [BindProperty]
        public int loggedUser { get; set; }


        public GetAllTasksModel(ITaskService tservice, IBidService bService)
        {
            taskService = tservice;
            bidService = bService;
        }

        public IActionResult OnGet()
        {
            loggedUser = User.GetUserId();
            if (string.IsNullOrEmpty(Criteria) || Criteria == "All")
            {
                tasks = taskService.GetAllTasks();
            }
            else
            {
                tasks = taskService.GetTasksFilteredByCategory(Criteria);
            }
            return Page();
        }
    }
}
