using Microsoft.AspNetCore.Mvc;
using Moq;
using MyTasks.Controllers;
using MyTasks.Core.Services.Interfaces.StatusType;
using MyTasksDataBase.Models;
using NUnit.Framework;

namespace TaskTest
{
    public class StatusControllerTests
    {
        private StatusController _statusController;
        private Mock<IStatusService> _statusServiceMock;

        [SetUp]
        public void SetUp()
        {
            _statusServiceMock = new Mock<IStatusService>();
            _statusController = new StatusController(_statusServiceMock.Object);
        }

        [Test]
        public async Task GetAllStatusesAsync_ReturnsList_Valid()
        {
            List<StatusModel> statusList = new List<StatusModel>
            {
                new StatusModel(),
                new StatusModel(),
                new StatusModel()
            };

            //Arrange
            _statusServiceMock.Setup(x => x.GetAllStatusesAsync()).ReturnsAsync(statusList);

            //Act
            var result = await _statusController.GetAllStatusesAsync();

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task DeleteStatusAsync_ReturnsVoid_Valid()
        {
            int id = 99999;

            //Arrange 
            _statusServiceMock.Setup(x => x.DeleteStatusAsync(id));

            //Act
            await _statusController.DeleteStatusAsync(id);

            //Assert
            _statusServiceMock.Verify(r => r.DeleteStatusAsync(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task GetStatusAsync_ReturnsStatusModel_Valid()
        {
            int id = 99999;

            //Arrange
            _statusServiceMock.Setup(x => x.GetStatusByIdAsync(id));

            //Act
            var result = await _statusController.GetStatusAsync(id);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task EditStatusAsync_ReturnsVoid_Valid()
        {
            StatusModelDto statusDto = new();

            //Arrange 
            _statusServiceMock.Setup(x => x.EditStatusAsync(statusDto));
            //Act
            await _statusController.EditStatusAsync(statusDto);

            //Assert
            _statusServiceMock.Verify(r => r.EditStatusAsync(It.IsAny<StatusModelDto>()), Times.Once);
        }

        [Test]
        public async Task CreateStatusAsync_ReturnsVoid_Valid()
        {
            StatusModelDto statusDto = new();

            //Arrange
            _statusServiceMock.Setup(x => x.CreateStatusAsync(statusDto));
            //Act
            await _statusController.CreateStatusAsync(statusDto);

            //Assert
            _statusServiceMock.Verify(r => r.CreateStatusAsync(It.IsAny<StatusModelDto>()), Times.Once);
        }
    }
}
