using Microsoft.EntityFrameworkCore;
using MyTasks.Core.DtoModels;
using MyTasks.Core.Services.Interfaces.ListOfTasks;
using MyTasksDataBase.Models;
using MyTasksDataBase.Repositories.Interfaces.Base;

namespace MyTasks.Core.Services.Realizations.ListOfTasks
{
    public class ListOfTasksService : IListOfTasksService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ListOfTasksService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task CreateListofTasksAsync(ListOfTasksModelDto listOfTasksModelDto)
        {
            var newList = new ListOfTasksModel { ListName = listOfTasksModelDto.ListName };
            _repositoryWrapper.ListOfTasksRepository.Create(newList);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task DeleteListAsync(int listOfTasksId)
        {
            var list = await _repositoryWrapper.ListOfTasksRepository.GetFisrtOrDefaultAsync(x => x.Id == listOfTasksId);
            _repositoryWrapper.ListOfTasksRepository.Delete(list);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task<List<ListOfTasksModel>> GetAllListsNamesAndIdAsync()
        {
            var listsData = await _repositoryWrapper.ListOfTasksRepository.GetAllListsNamesAndIdAsync();

            return listsData;
        }

        public async Task<ListOfTasksModel> GetListDataByIdAsync(int Id)
        {
            return await _repositoryWrapper.ListOfTasksRepository.GetFisrtOrDefaultAsync(predicate: x => x.Id == Id, include: y => y.Include(i => i.Tasks).Include(j => j.Statuses));
        }

        public async Task EditListOfTasksAsync(ListOfTasksModelDto listOfTasksModelDto)
        {
            var list = await _repositoryWrapper.ListOfTasksRepository.GetFisrtOrDefaultAsync(x => x.Id == listOfTasksModelDto.Id);
            var editList = new ListOfTasksModel
            {
                Id = listOfTasksModelDto.Id,
                ListName = listOfTasksModelDto.ListName,
                Statuses = list.Statuses,
                Tasks = list.Tasks,

            };

            _repositoryWrapper.ListOfTasksRepository.Update(editList);
            await _repositoryWrapper.SaveAsync();
        }
    }
}
