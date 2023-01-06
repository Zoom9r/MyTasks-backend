using MyTasks.Core.DtoModels;
using MyTasks.Core.Services.Interfaces.MyTask;
using MyTasksDataBase.Models;
using MyTasksDataBase.Repositories.Interfaces.Base;

namespace MyTasks.Core.Services.Realizations.MyTask
{
    public class TaskService : ITaskService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TaskService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
        {
            var task = await _repositoryWrapper.TaskRepository.GetAllAsync();

            return task;
        }

        public async Task CreateTaskAsync(TaskModelDto taskModelDto)
        {
            var status = await _repositoryWrapper.StatusRepository.GetFisrtOrDefaultAsync(x => x.Id == taskModelDto.StatusId);
            var list = await _repositoryWrapper.ListOfTasksRepository.GetFisrtOrDefaultAsync(x => x.Id == taskModelDto.ListOfTasksId);
            var task = new TaskModel { Title = taskModelDto.Title, Description = taskModelDto.Description, StatusId = status.Id, ListOfTasksId = list.Id };
            _repositoryWrapper.TaskRepository.Create(task);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            var task = await _repositoryWrapper.TaskRepository.GetFisrtOrDefaultAsync(x => x.Id == taskId);
            _repositoryWrapper.TaskRepository.Delete(task);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task EditTaskAsync(TaskModelDto task)
        {
            var list = await _repositoryWrapper.ListOfTasksRepository.GetFisrtOrDefaultAsync(x => x.Id == task.ListOfTasksId);
            var status = await _repositoryWrapper.StatusRepository.GetFisrtOrDefaultAsync(x => x.Id == task.StatusId);
            var editTask = new TaskModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                ListOfTasksId = task.ListOfTasksId,
                ListOfTasks = list,
                StatusId = task.StatusId,
                Status = status
            };
            _repositoryWrapper.TaskRepository.Update(editTask);

            await _repositoryWrapper.SaveAsync();
        }

        public async Task<TaskModel> GetTaskByIdAsync(int taskId)
        {
            return await _repositoryWrapper.TaskRepository.GetFisrtOrDefaultAsync(x => x.Id == taskId);
        }
    }
}
