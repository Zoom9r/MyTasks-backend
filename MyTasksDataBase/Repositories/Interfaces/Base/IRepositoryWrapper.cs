using MyTasksDataBase.Repositories.Interfaces.ListOfTasks;
using MyTasksDataBase.Repositories.Interfaces.MyTask;
using MyTasksDataBase.Repositories.Interfaces.StatusType;

namespace MyTasksDataBase.Repositories.Interfaces.Base
{
    public interface IRepositoryWrapper
    {
        ITaskRepository TaskRepository { get; }
        IStatusRepository StatusRepository { get; }
        IListOfTasksRepository ListOfTasksRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
