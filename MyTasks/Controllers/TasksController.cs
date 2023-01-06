using Microsoft.AspNetCore.Mvc;
using MyTasks.Core.Services.Interfaces.MyTask;
using MyTasks.Core.DtoModels;

namespace MyTasks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _myTaskService;

        public TasksController(ITaskService myTaskService)
        {
            _myTaskService = myTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasksAsync()
        {
            var tasks = await _myTaskService.GetAllTasksAsync();

            return Ok(tasks);
        }

        [HttpGet("{id}", Name = "GetTask")]// хз
        public async Task<IActionResult> GetTaskAsync(int taskId)
        {
            return Ok(await _myTaskService.GetTaskByIdAsync(taskId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync(TaskModelDto myTaskModelDto)
        {
            await _myTaskService.CreateTaskAsync(myTaskModelDto);

            return Ok();
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTaskAsync(int taskId)
        {
            await _myTaskService.DeleteTaskAsync(taskId);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditTaskAsync([FromBody] TaskModelDto taskModeldto)
        {
            await _myTaskService.EditTaskAsync(taskModeldto);

            return Ok();
        }
    }
}