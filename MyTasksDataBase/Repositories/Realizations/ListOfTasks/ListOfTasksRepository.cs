using Microsoft.EntityFrameworkCore;
using MyTasksDataBase.Models;
using MyTasksDataBase.Repositories.Interfaces.ListOfTasks;
using MyTasksDataBase.Repositories.Realizations.Base;

namespace MyTasksDataBase.Repositories.Realizations.ListOfTasks
{
    public class ListOfTasksRepository : RepositoryBase<ListOfTasksModel>, IListOfTasksRepository
    {
        private readonly MyTasksDBContext myTasksDBContext;

        public ListOfTasksRepository(MyTasksDBContext dBContext)
           : base(dBContext)
        {
            myTasksDBContext = dBContext;
        }

        public async Task<List<ListOfTasksModel>> GetAllListsNamesAndIdAsync()
        {
            var result = await myTasksDBContext.ListOfTasksModels.FromSqlRaw("getListsIdAndName").ToListAsync();
            return result;
        }
    }
}
