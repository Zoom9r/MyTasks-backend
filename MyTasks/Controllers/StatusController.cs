using Microsoft.AspNetCore.Mvc;
using MyTasks.Core.Services.Interfaces.StatusType;
using MyTasksDataBase.Models;

namespace MyTasks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStatusesAsync()
        {
            var statuses = await _statusService.GetAllStatusesAsync();

            return Ok(statuses);
        }

        [HttpGet("{statusId}")]
        public async Task<IActionResult> GetStatusAsync(int statusId)
        {
            var status = await _statusService.GetStatusByIdAsync(statusId);

            return Ok(status);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStatusAsync(StatusModelDto statusModelDto)
        {
            await _statusService.CreateStatusAsync(statusModelDto);

            return Ok();
        }

        [HttpDelete("{statusId}")]
        public async Task<IActionResult> DeleteStatusAsync(int statusId)
        {
            await _statusService.DeleteStatusAsync(statusId);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditStatusAsync([FromBody] StatusModelDto statusModelDto)
        {
            await _statusService.EditStatusAsync(statusModelDto);

            return Ok();
        }
    }
}
