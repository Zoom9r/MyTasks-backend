using MyTasks.Core.DtoModels;
using MyTasksDataBase.Models;

namespace MyTasks.Core.Services.Interfaces.MyTask
{
    public interface ITaskService
    {
        Task CreateTaskAsync(TaskModelDto taskModelDto);
        Task DeleteTaskAsync(int taskId);
        Task EditTaskAsync(TaskModelDto taskModelDto);
        Task<IEnumerable<TaskModel>> GetAllTasksAsync();
        Task<TaskModel> GetTaskByIdAsync(int taskId);
    }
}
