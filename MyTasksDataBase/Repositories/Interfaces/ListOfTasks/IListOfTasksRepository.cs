using MyTasksDataBase.Models;
using MyTasksDataBase.Repositories.Interfaces.Base;

namespace MyTasksDataBase.Repositories.Interfaces.ListOfTasks
{
    public interface IListOfTasksRepository : IRepositoryBase<ListOfTasksModel>
    {
        public Task<List<ListOfTasksModel>> GetAllListsNamesAndIdAsync();

    }
}
