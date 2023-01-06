using Microsoft.EntityFrameworkCore.Query;
using Moq;
using MyTasks.Core.DtoModels;
using MyTasks.Core.Services.Realizations.MyTask;
using MyTasksDataBase.Models;
using MyTasksDataBase.Repositories.Interfaces.Base;
using NUnit.Framework;
using System.Linq.Expressions;

namespace MyTasksTest
{
    [TestFixture]
    public class TaskServiceTests
    {
        private TaskService _myTaskService;
        private Mock<IRepositoryWrapper> _repositoryWrapperMock;

        [SetUp]
        public void SetUp()
        {
            _repositoryWrapperMock = new Mock<IRepositoryWrapper>();
            _myTaskService = new TaskService(_repositoryWrapperMock.Object);
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

            //Arrange 
            _repositoryWrapperMock.Setup(x =>
            x.TaskRepository.GetAllAsync(
                It.IsAny<Expression<Func<TaskModel, bool>>>(),
                It.IsAny<Func<IQueryable<TaskModel>, IIncludableQueryable<TaskModel, object>>>()
                )).ReturnsAsync(list);

            //Act 
            var result = await _myTaskService.GetAllTasksAsync();

            //Assert 
            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public async Task DeleteTaskAsync_ReturnsVoid_Valid()
        {
            TaskModel task1 = new();
            int id = 99999;

            //Arrange 
            _repositoryWrapperMock.Setup(x => x.TaskRepository.Delete(task1));

            //Act
            await _myTaskService.DeleteTaskAsync(id);

            //Assert
            _repositoryWrapperMock.Verify(r => r.TaskRepository.Delete(It.IsAny<TaskModel>()), Times.Once);
            _repositoryWrapperMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task GetTaskAsync_ReturnsTaskModel_Valid()
        {
            TaskModel task = new();
            int id = 99999;

            //Arrange
            _repositoryWrapperMock.Setup(x => x.TaskRepository.GetFisrtOrDefaultAsync(
                It.IsAny<Expression<Func<TaskModel, bool>>>(),
                It.IsAny<Func<IQueryable<TaskModel>, IIncludableQueryable<TaskModel, object>>>()
                )).ReturnsAsync(task);

            //Act
            var result = await _myTaskService.GetTaskByIdAsync(id);

            //Assert
            Assert.IsInstanceOf<TaskModel>(result);
        }

        [Test]
        public async Task EditTaskAsync_ReturnsVoid_Valid()
        {
            TaskModel task = new();
            TaskModelDto taskDto = new();
            ListOfTasksModel list = new();
            StatusModel status = new();

            //Arrange 
            _repositoryWrapperMock.Setup(x => x.TaskRepository.Update(task));
            _repositoryWrapperMock.Setup(y => y.ListOfTasksRepository.GetFisrtOrDefaultAsync(
                It.IsAny<Expression<Func<ListOfTasksModel, bool>>>(),
                It.IsAny<Func<IQueryable<ListOfTasksModel>, IIncludableQueryable<ListOfTasksModel, object>>>()
                )).ReturnsAsync(list);
            _repositoryWrapperMock.Setup(z => z.StatusRepository.GetFisrtOrDefaultAsync(
                It.IsAny<Expression<Func<StatusModel, bool>>>(),
                It.IsAny<Func<IQueryable<StatusModel>, IIncludableQueryable<StatusModel, object>>>()
                )).ReturnsAsync(status);

            //Act
            await _myTaskService.EditTaskAsync(taskDto);

            //Assert
            _repositoryWrapperMock.Verify(r => r.TaskRepository.Update(It.IsAny<TaskModel>()), Times.Once);
            _repositoryWrapperMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task CreateTaskAsync_ReturnsVoid_Valid()
        {
            TaskModel task = new();
            TaskModelDto taskDto = new();
            ListOfTasksModel list = new();
            StatusModel status = new();

            //Arrange
            _repositoryWrapperMock.Setup(x => x.TaskRepository.Create(task));
            _repositoryWrapperMock.Setup(y => y.ListOfTasksRepository.GetFisrtOrDefaultAsync(
                It.IsAny<Expression<Func<ListOfTasksModel, bool>>>(),
                It.IsAny<Func<IQueryable<ListOfTasksModel>, IIncludableQueryable<ListOfTasksModel, object>>>()
                )).ReturnsAsync(list);
            _repositoryWrapperMock.Setup(z => z.StatusRepository.GetFisrtOrDefaultAsync(
                It.IsAny<Expression<Func<StatusModel, bool>>>(),
                It.IsAny<Func<IQueryable<StatusModel>, IIncludableQueryable<StatusModel, object>>>()
                )).ReturnsAsync(status);

            //Act
            await _myTaskService.CreateTaskAsync(taskDto);

            //Assert
            _repositoryWrapperMock.Verify(r => r.TaskRepository.Create(It.IsAny<TaskModel>()), Times.Once);
            _repositoryWrapperMock.Verify(r => r.SaveAsync(), Times.Once);
        }
    }
}