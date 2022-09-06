using MyTasksDataBase.Repositories.Interfaces.MyTask;


namespace MyTasksDataBase.Repositories.Interfaces.Base
{
    public interface IRepositoryWrapper
    {
        IMyTaskRepository MyTaskRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
