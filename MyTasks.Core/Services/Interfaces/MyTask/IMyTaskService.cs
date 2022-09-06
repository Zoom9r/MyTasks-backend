using MyTasksDataBase.Models;
using System.Collections;

namespace MyTasks.Core.Services.Interfaces.MyTask
{
    public interface IMyTaskService
    {
        Task CreateTaskAsync(TaskModel taskModel);
        Task DeleteTaskAsync(int taskId);
        Task EditTaskAsync(TaskModel taskModel);
        Task<IEnumerable<TaskModel>> GetAllTasksAsync();
        Task<TaskModel> GetTaskAsync(int taskId);
    }
}
