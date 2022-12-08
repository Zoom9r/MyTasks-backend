using MyTasks.Core.Services.Interfaces.StatusType;
using MyTasksDataBase.Models;
using MyTasksDataBase.Repositories.Interfaces.Base;

namespace MyTasks.Core.Services.Realizations.Status
{
    public class StatusService : IStatusService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public StatusService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task CreateStatusAsync(StatusModelDto statusModelDto)
        {
            var newStatus = new StatusModel { StatusName = statusModelDto.StatusName, ListOfTasksId = statusModelDto.ListOfTasksId };
            _repositoryWrapper.StatusRepository.Create(newStatus);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task DeleteStatusAsync(int statusId)
        {
            var status = await _repositoryWrapper.StatusRepository.GetFisrtOrDefaultAsync(x => x.Id == statusId);
            _repositoryWrapper.StatusRepository.Delete(status);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task EditStatusAsync(StatusModelDto statusModelDto)
        {
            var list = await _repositoryWrapper.ListOfTasksRepository.GetFisrtOrDefaultAsync(x => x.Id == statusModelDto.ListOfTasksId);

            var editStatus = new StatusModel
            {
                Id = statusModelDto.Id,
                StatusName = statusModelDto.StatusName,
                ListOfTasksId = statusModelDto.ListOfTasksId,
                ListOfTasks = list

            };
            _repositoryWrapper.StatusRepository.Update(editStatus);

            await _repositoryWrapper.SaveAsync();
        }

        public async Task<IEnumerable<StatusModel>> GetAllStatusesAsync()
        {
            var statuses = await _repositoryWrapper.StatusRepository.GetAllAsync();
            return statuses;
        }

        public async Task<StatusModel> GetStatusByIdAsync(int statusId)
        {
            var status = await _repositoryWrapper.StatusRepository.GetFisrtOrDefaultAsync(x => x.Id == statusId);
            return status;
        }
    }
}
