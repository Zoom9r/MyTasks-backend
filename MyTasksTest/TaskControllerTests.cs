﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using MyTasks.Controllers;
using MyTasks.Core.Services.Interfaces.MyTask;
using MyTasksDataBase.Models;
using NUnit.Framework;

namespace MyTasksTest
{
    [TestFixture]
    public class TaskControllerTests
    {
        private MyTasksController _myTasksController;
        private Mock<IMyTaskService> _myTaskServiceMock; // моки- підставляються замість інтерфейсів і можуть передавати "фейкові" дані в реалізації інтерфейсів.

        [SetUp] // Частина коду яка вiдбувається перед запуском тестів
        public void SetUp()
        {
            _myTaskServiceMock = new Mock<IMyTaskService>();
            _myTasksController = new MyTasksController(_myTaskServiceMock.Object);
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
            //Arrange - тут створюються всі необхідні фейкові дані що звязані з тестуємим методом
            _myTaskServiceMock.Setup(x => x.GetAllTasksAsync()).ReturnsAsync(list);
            //Act - тут ми викликаємо сам метод який проходить перевідку
            var result = await _myTasksController.GetAllTasksAsync();
            //Assert - тут перевіряємо чи пройшов метод по необхідним нам критеріям
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task DeleteTaskAsync_ReturnsVoid_Valid()
        {
            int id = 99999;

            //Arrange 
            _myTaskServiceMock.Setup(x => x.DeleteTaskAsync(id));

            //Act
            await _myTasksController.DeleteTaskAsync(id);

            //Assert
            _myTaskServiceMock.Verify(r => r.DeleteTaskAsync(It.IsAny<int>()), Times.Once);

        }
        [Test]
        public async Task GetTaskAsync_ReturnsTaskModel_Valid()
        {
            int id = 99999;

            //Arrange
            _myTaskServiceMock.Setup(x => x.GetTaskAsync(id));

            //Act
            var x = await _myTasksController.GetTaskAsync(id);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(x);
        }
        [Test]
        public async Task EditTaskAsync_ReturnsVoid_Valid()
        {
            TaskModel task = new();

            //Arrange 
            _myTaskServiceMock.Setup(x => x.EditTaskAsync(task));
            //Act
            await _myTasksController.EditTaskAsync(task);

            //Assert
            _myTaskServiceMock.Verify(r => r.EditTaskAsync(It.IsAny<TaskModel>()), Times.Once);
        }
        [Test]
        public async Task CreateTaskAsync_ReturnsVoid_Valid()
        {
            TaskModel task = new();

            //Arrange - тут створюються фейкові дані
            _myTaskServiceMock.Setup(x => x.CreateTaskAsync(task));
            //Act
            await _myTasksController.CreateTaskAsync(task);

            //Assert
            _myTaskServiceMock.Verify(r => r.CreateTaskAsync(It.IsAny<TaskModel>()), Times.Once);
        }
    }
}
