using MyTasksDataBase.Models;

namespace MyTasks.Core.Services.Interfaces.StatusType
{
    public interface IStatusService
    {
        Task<IEnumerable<StatusModel>> GetAllStatusesAsync();
        Task CreateStatusAsync(StatusModelDto statusTypeModelDto);
        Task<StatusModel> GetStatusByIdAsync(int statusId);
        Task EditStatusAsync(StatusModelDto statusModelDto);
        Task DeleteStatusAsync(int statusId);
    }
}
