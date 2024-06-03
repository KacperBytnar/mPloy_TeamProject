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

        public Models.Task UpdateTask(Models.Task task, int creatorID)
        {

            Models.Task tsk = context.Tasks.Where(t => t.TaskID == task.TaskID).FirstOrDefault();
            if (tsk != null)
            {
                task.CreatorID = creatorID;
                tsk.Title = task.Title;
                tsk.Location = task.Location;
                tsk.Description = task.Description;
                tsk.Categories = task.Categories;
                tsk.Location = task.Location;
                tsk.Prize = task.Prize;
                tsk.Payment = task.Payment;
                context.SaveChanges();
            }
            return task;
        }

        public void EditTask(Models.Task task, int creatorID)
        {
            task.CreatorID = creatorID;
            context.Tasks.Update(task);
            context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            Models.Task task = context.Tasks.Where(t => t.TaskID == id).FirstOrDefault();
            context.Tasks.Remove(task);
            context.SaveChanges();

        }
    }
}
