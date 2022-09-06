using MyTasks.Core.Services.Interfaces.MyTask;
using MyTasksDataBase.Models;
using MyTasksDataBase.Repositories.Interfaces.Base;

namespace MyTasks.Core.Services.Realizations.MyTask
{
    public class MyTaskService : IMyTaskService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MyTaskService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task CreateTaskAsync(TaskModel taskModel)
        {
            _repositoryWrapper.MyTaskRepository.Create(taskModel);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task DeleteTaskAsync(int taskId)
        {
            var task = await _repositoryWrapper.MyTaskRepository.GetFisrtOrDefaultAsync(x => x.Id == taskId);
            _repositoryWrapper.MyTaskRepository.Delete(task);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task EditTaskAsync(TaskModel taskModel)
        {
            _repositoryWrapper.MyTaskRepository.Update(taskModel);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
        {
            var task = await _repositoryWrapper.MyTaskRepository.GetAllAsync();
            return task;
        }

        public async Task<TaskModel> GetTaskAsync(int taskId)
        {
            return await _repositoryWrapper.MyTaskRepository.GetFisrtOrDefaultAsync(x => x.Id == taskId);
        }
    }
}
