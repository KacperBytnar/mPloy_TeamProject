namespace mPloy_TeamProjectG5.Services.Interfaces
{
    public interface ITaskService
    {
        void CreateTask(Models.Task task, int creatorID);
        public IEnumerable<Models.Task> GetTasksFilteredByCategory(string category);
        public IEnumerable<Models.Task> GetUserTasksCreatedByUserId(int userID);
        public Models.Task GetTask(int id);
        public IEnumerable<Models.Task> GetAllTasks();
    }
}
