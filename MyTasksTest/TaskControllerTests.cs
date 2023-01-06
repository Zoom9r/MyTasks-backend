using Microsoft.AspNetCore.Mvc;
using Moq;
using MyTasks.Controllers;
using MyTasks.Core.DtoModels;
using MyTasks.Core.Services.Interfaces.MyTask;
using MyTasksDataBase.Models;
using NUnit.Framework;

namespace MyTasksTest
{
    [TestFixture]
    public class TaskControllerTests
    {
        private TasksController _tasksController;
        private Mock<ITaskService> _taskServiceMock;

        [SetUp]
        public void SetUp()
        {
            _taskServiceMock = new Mock<ITaskService>();
            _tasksController = new TasksController(_taskServiceMock.Object);
        }

        [Test]
        public async Task GetAllTasksAsync_ReturnsList_Valid()
        {
            List<TaskModel> list = new List<TaskModel>
            {
                new TaskModel(),
                new TaskModel(),
                new TaskModel()
            };

            //Arrange
            _taskServiceMock.Setup(x => x.GetAllTasksAsync()).ReturnsAsync(list);

            //Act
            var result = await _tasksController.GetAllTasksAsync();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task DeleteTaskAsync_ReturnsVoid_Valid()
        {
            int id = 99999;

            //Arrange 
            _taskServiceMock.Setup(x => x.DeleteTaskAsync(id));

            //Act
            await _tasksController.DeleteTaskAsync(id);

            //Assert
            _taskServiceMock.Verify(r => r.DeleteTaskAsync(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task GetTaskAsync_ReturnsTaskModel_Valid()
        {
            int id = 99999;

            //Arrange
            _taskServiceMock.Setup(x => x.GetTaskByIdAsync(id));

            //Act
            var x = await _tasksController.GetTaskAsync(id);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(x);
        }

        [Test]
        public async Task EditTaskAsync_ReturnsVoid_Valid()
        {
            TaskModelDto task = new();

            //Arrange 
            _taskServiceMock.Setup(x => x.EditTaskAsync(task));

            //Act
            await _tasksController.EditTaskAsync(task);

            //Assert
            _taskServiceMock.Verify(r => r.EditTaskAsync(It.IsAny<TaskModelDto>()), Times.Once);
        }

        [Test]
        public async Task CreateTaskAsync_ReturnsVoid_Valid()
        {
            TaskModelDto task = new();

            //Arrange
            _taskServiceMock.Setup(x => x.CreateTaskAsync(task));
            //Act
            await _tasksController.CreateTaskAsync(task);

            //Assert
            _taskServiceMock.Verify(r => r.CreateTaskAsync(It.IsAny<TaskModelDto>()), Times.Once);
        }

    }
}
