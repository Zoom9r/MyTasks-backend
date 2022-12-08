using MyTasksDataBase.Models;
using MyTasksDataBase.Repositories.Interfaces.StatusType;
using MyTasksDataBase.Repositories.Realizations.Base;


namespace MyTasksDataBase.Repositories.Realizations.Status
{
    public class StatusRepository : RepositoryBase<StatusModel>, IStatusRepository
    {
        public StatusRepository(MyTasksDBContext dBContext)
           : base(dBContext)
        {

        }
    }
}
