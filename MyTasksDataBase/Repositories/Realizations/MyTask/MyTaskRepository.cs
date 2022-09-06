using MyTasksDataBase.Models;
using MyTasksDataBase.Repositories.Interfaces.MyTask;
using MyTasksDataBase.Repositories.Realizations.Base;

namespace MyTasksDataBase.Repositories.Realizations.MyTask
{
    public class MyTaskRepository : RepositoryBase<TaskModel>, IMyTaskRepository
    {
        public MyTaskRepository(MyTasksDBContext dBContext)
            : base(dBContext)
        {

        }
    }
}
