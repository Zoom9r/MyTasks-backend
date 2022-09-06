using Microsoft.AspNetCore.Mvc;
using MyTasks.Core.Services.Interfaces.MyTask;
using MyTasksDataBase.Models;

namespace MyTasks.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MyTasksController : ControllerBase
    {
        private readonly IMyTaskService _myTaskService;
        public MyTasksController(IMyTaskService myTaskService)
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
            return Ok(await _myTaskService.GetTaskAsync(taskId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync(TaskModel myTaskModel)
        {
            await _myTaskService.CreateTaskAsync(myTaskModel);
            return Ok();

        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTaskAsync(int taskId)
        {
            await _myTaskService.DeleteTaskAsync(taskId);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditTaskAsync([FromBody] TaskModel taskModel)
        {
            await _myTaskService.EditTaskAsync(taskModel);
            return Ok();
        }
    }
}