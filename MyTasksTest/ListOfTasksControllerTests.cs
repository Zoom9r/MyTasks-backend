using Microsoft.AspNetCore.Mvc;
using Moq;
using MyTasks.Controllers;
using MyTasks.Core.DtoModels;
using MyTasks.Core.Services.Interfaces.ListOfTasks;
using MyTasksDataBase.Models;
using NUnit.Framework;

namespace TaskTest
{
    public class ListOfTasksControllerTests
    {
        private ListOfTasksController _listOfTasksController;
        private Mock<IListOfTasksService> _listOfTasksServiceMock;

        [SetUp]
        public void SetUp()
        {
            _listOfTasksServiceMock = new Mock<IListOfTasksService>();
            _listOfTasksController = new ListOfTasksController(_listOfTasksServiceMock.Object);
        }

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
            _listOfTasksServiceMock.Setup(x => x.GetAllListsNamesAndIdAsync()).ReturnsAsync(list);

            //Act
            var result = await _listOfTasksController.GetAllListsNamesAndIdAsync();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task DeleteListAsync_ReturnsVoid_Valid()
        {
            int id = 99999;

            //Arrange 
            _listOfTasksServiceMock.Setup(x => x.DeleteListAsync(id));

            //Act
            await _listOfTasksController.DeleteListAsync(id);

            //Assert
            _listOfTasksServiceMock.Verify(r => r.DeleteListAsync(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task GetListsDataById_ReturnsListOfTasksModel_NotValid()
        {
            int id = 99999;

            //Arrange
            _listOfTasksServiceMock.Setup(x => x.GetListDataByIdAsync(id));

            //Act
            var result = await _listOfTasksController.GetListsDataByIdAsync(id);

            //Assert
            Assert.IsNotInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task EditListAsync_ReturnsVoid_Valid()
        {
            ListOfTasksModelDto list = new();

            //Arrange 
            _listOfTasksServiceMock.Setup(x => x.EditListOfTasksAsync(list));

            //Act
            await _listOfTasksController.EditListAsync(list);

            //Assert
            _listOfTasksServiceMock.Verify(r => r.EditListOfTasksAsync(It.IsAny<ListOfTasksModelDto>()), Times.Once);
        }

        [Test]
        public async Task CreateListOfTasksAsync_ReturnsVoid_Valid()
        {
            ListOfTasksModelDto listDto = new();

            //Arrange
            _listOfTasksServiceMock.Setup(x => x.CreateListofTasksAsync(listDto));

            //Act
            await _listOfTasksController.CreateListOfTasksAsync(listDto);

            //Assert
            _listOfTasksServiceMock.Verify(r => r.CreateListofTasksAsync(It.IsAny<ListOfTasksModelDto>()), Times.Once);
        }
    }
}
