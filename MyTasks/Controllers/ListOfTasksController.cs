using Microsoft.AspNetCore.Mvc;
using MyTasks.Core.DtoModels;
using MyTasks.Core.Services.Interfaces.ListOfTasks;

namespace MyTasks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListOfTasksController : ControllerBase
    {
        private readonly IListOfTasksService _listOfTasksService;

        public ListOfTasksController(IListOfTasksService listOfTasksService)
        {
            _listOfTasksService = listOfTasksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllListsNamesAndIdAsync()
        {
            var listsData = await _listOfTasksService.GetAllListsNamesAndIdAsync();

            return Ok(listsData);
        }

        [HttpPost]
        public async Task<IActionResult> CreateListOfTasksAsync(ListOfTasksModelDto listOfTasksModelDto)
        {
            await _listOfTasksService.CreateListofTasksAsync(listOfTasksModelDto);

            return Ok();
        }

        [HttpDelete("{listOfTasksId}")]
        public async Task<IActionResult> DeleteListAsync(int listOfTasksId)
        {
            await _listOfTasksService.DeleteListAsync(listOfTasksId);

            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetListsDataByIdAsync(int id)
        {
            var listOfTasks = await _listOfTasksService.GetListDataByIdAsync(id);

            return listOfTasks != null ? Ok(listOfTasks) : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> EditListAsync([FromBody] ListOfTasksModelDto list)
        {
            await _listOfTasksService.EditListOfTasksAsync(list);

            return Ok();
        }
    }
}
