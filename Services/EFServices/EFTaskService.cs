using Microsoft.AspNetCore.Identity;
using mPloy_TeamProjectG5.Models;
using mPloy_TeamProjectG5.Services.Interfaces;

namespace mPloy_TeamProjectG5.Services.EFServices
{
    public class EFTaskService : ITaskService
    {
        private AppDbContext context;
        private readonly UserManager<AppUser> userManager;

        public EFTaskService(AppDbContext dbcontext, UserManager<AppUser> userManager)
        {
            context = dbcontext;
            this.userManager = userManager;
        }
        public void CreateTask(Models.Task task, int creatorID)
        {
            task.CreatorID = creatorID;/*userManager.GetUserId(userManager.GetUserAsync())*/
            context.Tasks.Add(task);
            context.SaveChanges();
        }
    }
}
