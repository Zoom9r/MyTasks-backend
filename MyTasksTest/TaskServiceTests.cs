using Microsoft.EntityFrameworkCore.Query;
using Moq;
using MyTasks.Core.Services.Realizations.MyTask;
using MyTasksDataBase.Models;
using MyTasksDataBase.Repositories.Interfaces.Base;
using NUnit;
using NUnit.Framework;
using System.Linq.Expressions;

namespace MyTasksTest
{
    [TestFixture]
    public class TaskServiceTests
    {
        private MyTaskService _myTaskService;
        private Mock<IRepositoryWrapper> _repositoryWrapperMock; // моки- підставляються замість інтерфейсів і можуть передавати "фейкові" дані в реалізації інтерфейсів.

        [SetUp] // Частина коду яка вiдбувається перед запуском тестів
        public void SetUp()
        {
            _repositoryWrapperMock = new Mock<IRepositoryWrapper>();
            _myTaskService = new MyTaskService(_repositoryWrapperMock.Object);
        }
        [Test]
        public async Task GetAllTasks_ReturnsList_Valid()
        {
            List<TaskModel> list = new List<TaskModel>
            {
                new TaskModel(),
                new TaskModel(),
                new TaskModel()


            };
            //Arrange - тут створюються всі необхідні фейкові дані що звязані з тестуємим методом
            _repositoryWrapperMock.Setup(x =>
            x.MyTaskRepository.GetAllAsync(
                It.IsAny<Expression<Func<TaskModel, bool>>>(),
                It.IsAny<Func<IQueryable<TaskModel>, IIncludableQueryable<TaskModel, object>>>()
                )).ReturnsAsync(list);

            //Act - тут ми викликаємо сам метод який проходить перевідку
            var result = await _myTaskService.GetAllTasksAsync();

            //Assert - тут перевіряємо чи пройшов метод по необхідним нам критеріям
            Assert.AreEqual(3, result.Count());

        }

        [Test]
        public async Task DeleteTask_ReturnsVoid_Valid()
        {
            TaskModel task1 = new();
            int id = 99999;

            //Arrange 
            _repositoryWrapperMock.Setup(x => x.MyTaskRepository.Delete(task1));

            //Act
            await _myTaskService.DeleteTaskAsync(id);

            //Assert
            _repositoryWrapperMock.Verify(r => r.MyTaskRepository.Delete(It.IsAny<TaskModel>()), Times.Once);
            _repositoryWrapperMock.Verify(r => r.SaveAsync(), Times.Once);
        }
        [Test]
        public async Task GetTaskAsync_ReturnsTaskModel_Valid()
        {
            TaskModel task = new();
            int id = 99999;

            //Arrange
            _repositoryWrapperMock.Setup(x => x.MyTaskRepository.GetFisrtOrDefaultAsync(
                It.IsAny<Expression<Func<TaskModel, bool>>>(),
                It.IsAny<Func<IQueryable<TaskModel>, IIncludableQueryable<TaskModel, object>>>()
                )).ReturnsAsync(task);

            //Act
            var x = await _myTaskService.GetTaskAsync(id);

            //Assert
            Assert.IsInstanceOf<TaskModel>(x);
        }
        [Test]
        public async Task EditTaskAsync_ReturnsVoid_Valid()
        {
            TaskModel task = new();
            int id = 99999;

            //Arrange 
            _repositoryWrapperMock.Setup(x => x.MyTaskRepository.Update(task));
            //Act
            await _myTaskService.EditTaskAsync(task);

            //Assert
            _repositoryWrapperMock.Verify(r => r.MyTaskRepository.Update(It.IsAny<TaskModel>()), Times.Once);
            _repositoryWrapperMock.Verify(r => r.SaveAsync(), Times.Once);
        }
        [Test]
        public async Task CreateTaskAsync_ReturnsVoid_Valid()
        {
            TaskModel task = new();
            int id = 99999;

            //Arrange - тут створюються фейкові дані
            _repositoryWrapperMock.Setup(x => x.MyTaskRepository.Create(task));
            //Act
            await _myTaskService.CreateTaskAsync(task);

            //Assert
            _repositoryWrapperMock.Verify(r => r.MyTaskRepository.Create(It.IsAny<TaskModel>()), Times.Once);
            _repositoryWrapperMock.Verify(r => r.SaveAsync(), Times.Once);
        }
    }
}