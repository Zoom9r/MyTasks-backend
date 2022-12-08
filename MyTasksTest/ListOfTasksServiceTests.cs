using MyTasks.Core.Services.Realizations.ListOfTasks;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using MyTasks.Core.DtoModels;
using MyTasksDataBase.Models;
using MyTasksDataBase.Repositories.Interfaces.Base;
using NUnit.Framework;
using System.Linq.Expressions;

namespace TaskTest
{
    public class ListOfTasksServiceTests
    {
        private ListOfTasksService _listOfTasksService;
        private Mock<IRepositoryWrapper> _repositoryWrapperMock;

        [SetUp] 
        public void SetUp()
        {
            _repositoryWrapperMock = new Mock<IRepositoryWrapper>();
            _listOfTasksService = new ListOfTasksService(_repositoryWrapperMock.Object);
        }
        // Тести
        [Test]
        public async Task GetAllListsNamesAndIdAsync_ReturnsList_Valid()
        {
            List<ListOfTasksModel> list = new List<ListOfTasksModel>
            {
                new ListOfTasksModel(),
                new ListOfTasksModel(),
                new ListOfTasksModel()

            };
            //Arrange 
            _repositoryWrapperMock.Setup(x =>
            x.ListOfTasksRepository.GetAllListsNamesAndIdAsync()).ReturnsAsync(list);

            //Act 
            var result = await _listOfTasksService.GetAllListsNamesAndIdAsync();

            //Assert 
            Assert.AreEqual(3, result.Count);

        }

        [Test]
        public async Task DeleteListAsync_ReturnsVoid_Valid()
        {
            ListOfTasksModel list = new();
            int id = 99999;

            //Arrange 
            _repositoryWrapperMock.Setup(x => x.ListOfTasksRepository.Delete(list));

            //Act
            await _listOfTasksService.DeleteListAsync(id);

            //Assert
            _repositoryWrapperMock.Verify(r => r.ListOfTasksRepository.Delete(It.IsAny<ListOfTasksModel>()), Times.Once);
            _repositoryWrapperMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task GetListDataByIdAsync_ReturnsListOfTasksModel_Valid()
        {
            ListOfTasksModel list = new();
            int id = 99999;

            //Arrange
            _repositoryWrapperMock.Setup(x => x.ListOfTasksRepository.GetFisrtOrDefaultAsync(
                It.IsAny<Expression<Func<ListOfTasksModel, bool>>>(),
                It.IsAny<Func<IQueryable<ListOfTasksModel>, IIncludableQueryable<ListOfTasksModel, object>>>()
                )).ReturnsAsync(list);

            //Act
            var result = await _listOfTasksService.GetListDataByIdAsync(id);

            //Assert
            Assert.IsInstanceOf<ListOfTasksModel>(result);
        }

        [Test]
        public async Task EditListOfTasksAsync_ReturnsVoid_Valid()
        {

            ListOfTasksModel list = new();
            ListOfTasksModelDto listDto = new();

            //Arrange 
            _repositoryWrapperMock.Setup(x => x.ListOfTasksRepository.Update(list));
            _repositoryWrapperMock.Setup(x => x.ListOfTasksRepository.GetFisrtOrDefaultAsync(
                It.IsAny<Expression<Func<ListOfTasksModel, bool>>>(),
                It.IsAny<Func<IQueryable<ListOfTasksModel>, IIncludableQueryable<ListOfTasksModel, object>>>()
                )).ReturnsAsync(list);

            //Act
            await _listOfTasksService.EditListOfTasksAsync(listDto);

            //Assert
            _repositoryWrapperMock.Verify(r => r.ListOfTasksRepository.Update(It.IsAny<ListOfTasksModel>()), Times.Once);
            _repositoryWrapperMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task CreateListOfTaskAsync_ReturnsVoid_Valid()
        {
            TaskModel task = new();
            TaskModelDto taskDto = new();
            ListOfTasksModel list = new();
            ListOfTasksModelDto listDto = new();
            StatusModel status = new();

            //Arrange 
            _repositoryWrapperMock.Setup(x => x.ListOfTasksRepository.Create(list));

            //Act
            await _listOfTasksService.CreateListofTasksAsync(listDto);

            //Assert
            _repositoryWrapperMock.Verify(r => r.ListOfTasksRepository.Create(It.IsAny<ListOfTasksModel>()), Times.Once);
            _repositoryWrapperMock.Verify(r => r.SaveAsync(), Times.Once);
        }

    }
}
