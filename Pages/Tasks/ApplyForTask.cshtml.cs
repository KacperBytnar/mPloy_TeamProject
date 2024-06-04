using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mPloy_TeamProjectG5.Common;
using mPloy_TeamProjectG5.Models;
using mPloy_TeamProjectG5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mPloy_TeamProjectG5.Pages.Tasks
{
    public class ApplyForTaskModel : PageModel
    {
        [BindProperty]
        public int UserID { get; set; }
        [BindProperty]
        public int TaskID { get; set; }
        IBidService bidService;
        UserBidOnTask userBid { get; set; } = new UserBidOnTask();

        public ApplyForTaskModel(IBidService bidService)
        {
            this.bidService = bidService;
        }
        public IActionResult OnGet(int taskID)
        {
            userBid.UserID = User.GetUserId();
            userBid.TaskID = taskID;
            userBid.isAccepted = false;
            bidService.CreateBid(userBid);
            return Redirect("/Tasks/GetAllTasks");
        }
    }
}
