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

        public IEnumerable<Models.Task> GetAllTasks()
        {
            return context.Tasks;
        }

        public Models.Task GetTask(int id)
        {
            return context.Tasks.Where(t => t.TaskID == id).FirstOrDefault(t => t.TaskID == id);
        }

        public IEnumerable<Models.Task> GetUserTasksCreatedByUserId(int userID)
        {
            return context.Tasks.Where(t => t.CreatorID == userID).ToList();
        }

        public IEnumerable<Models.Task> GetTasksFilteredByCategory(string category)
        {
            Common.Enums.TaskCategory MyEnum;
            var result = Enum.TryParse(category, out MyEnum);
            return context.Tasks.Where(t => t.Categories == MyEnum).ToList();
        }
    }
}
