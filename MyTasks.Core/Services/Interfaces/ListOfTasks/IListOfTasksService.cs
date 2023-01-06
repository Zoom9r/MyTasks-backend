using MyTasks.Core.DtoModels;
using MyTasksDataBase.Models;

namespace MyTasks.Core.Services.Interfaces.ListOfTasks
{
    public interface IListOfTasksService
    {
        Task<List<ListOfTasksModel>> GetAllListsNamesAndIdAsync();
        Task CreateListofTasksAsync(ListOfTasksModelDto listOfTasksModelDto);
        Task<ListOfTasksModel> GetListDataByIdAsync(int id);
        Task EditListOfTasksAsync(ListOfTasksModelDto listOfTasksModelDto);
        Task DeleteListAsync(int id);
    }
}
