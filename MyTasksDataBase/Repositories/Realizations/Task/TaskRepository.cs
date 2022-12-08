using MyTasksDataBase.Models;
using MyTasksDataBase.Repositories.Interfaces.MyTask;
using MyTasksDataBase.Repositories.Realizations.Base;

namespace MyTasksDataBase.Repositories.Realizations.MyTask
{
    public class TaskRepository : RepositoryBase<TaskModel>, ITaskRepository
    {
        public TaskRepository(MyTasksDBContext dBContext)
            : base(dBContext)
        {

        }
    }
}
