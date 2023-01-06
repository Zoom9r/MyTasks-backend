using Microsoft.EntityFrameworkCore.Query;
using Moq;
using MyTasks.Core.Services.Realizations.Status;
using MyTasksDataBase.Models;
using MyTasksDataBase.Repositories.Interfaces.Base;
using NUnit.Framework;
using System.Linq.Expressions;

namespace TaskTest
{
    public class StatusServiceTests
    {
        private StatusService _statusService;
        private Mock<IRepositoryWrapper> _repositoryWrapperMock;

        [SetUp]
        public void SetUp()
        {
            _repositoryWrapperMock = new Mock<IRepositoryWrapper>();
            _statusService = new StatusService(_repositoryWrapperMock.Object);
        }

        [Test]
        public async Task GetAllStatusesAsync_ReturnsList_Valid()
        {
            List<StatusModel> status = new List<StatusModel>
            {
                new StatusModel(),
                new StatusModel(),
                new StatusModel()
            };

            //Arrange 
            _repositoryWrapperMock.Setup(x =>
            x.StatusRepository.GetAllAsync(
                It.IsAny<Expression<Func<StatusModel, bool>>>(),
                It.IsAny<Func<IQueryable<StatusModel>, IIncludableQueryable<StatusModel, object>>>()
                )).ReturnsAsync(status);

            //Act 
            var result = await _statusService.GetAllStatusesAsync();

            //Assert 
            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public async Task DeleteStatusAsync_ReturnsVoid_Valid()
        {
            StatusModel status = new();
            int id = 99999;

            //Arrange 
            _repositoryWrapperMock.Setup(x => x.StatusRepository.Delete(status));

            //Act
            await _statusService.DeleteStatusAsync(id);

            //Assert
            _repositoryWrapperMock.Verify(r => r.StatusRepository.Delete(It.IsAny<StatusModel>()), Times.Once);
            _repositoryWrapperMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task GetStatusAsync_ReturnsStatusModel_Valid()
        {
            StatusModel status = new();
            int id = 99999;

            //Arrange
            _repositoryWrapperMock.Setup(y => y.StatusRepository.GetFisrtOrDefaultAsync(
                It.IsAny<Expression<Func<StatusModel, bool>>>(),
                It.IsAny<Func<IQueryable<StatusModel>, IIncludableQueryable<StatusModel, object>>>()
                )).ReturnsAsync(status);

            //Act
            var result = await _statusService.GetStatusByIdAsync(id);

            //Assert
            Assert.IsInstanceOf<StatusModel>(result);
        }

        [Test]
        public async Task EditStatusAsync_ReturnsVoid_Valid()
        {
            ListOfTasksModel list = new();
            StatusModel status = new();
            StatusModelDto statusDto = new();

            //Arrange 
            _repositoryWrapperMock.Setup(x => x.StatusRepository.Update(status));
            _repositoryWrapperMock.Setup(y => y.ListOfTasksRepository.GetFisrtOrDefaultAsync(
                It.IsAny<Expression<Func<ListOfTasksModel, bool>>>(),
                It.IsAny<Func<IQueryable<ListOfTasksModel>, IIncludableQueryable<ListOfTasksModel, object>>>()
                )).ReturnsAsync(list);

            //Act
            await _statusService.EditStatusAsync(statusDto);

            //Assert
            _repositoryWrapperMock.Verify(r => r.StatusRepository.Update(It.IsAny<StatusModel>()), Times.Once);
            _repositoryWrapperMock.Verify(r => r.SaveAsync(), Times.Once);
        }

        [Test]
        public async Task CreateStatusAsync_ReturnsVoid_Valid()
        {
            StatusModel status = new();
            StatusModelDto statusDto = new();

            //Arrange 
            _repositoryWrapperMock.Setup(x => x.StatusRepository.Create(status));

            //Act
            await _statusService.CreateStatusAsync(statusDto);

            //Assert
            _repositoryWrapperMock.Verify(r => r.StatusRepository.Create(It.IsAny<StatusModel>()), Times.Once);
            _repositoryWrapperMock.Verify(r => r.SaveAsync(), Times.Once);
        }
    }
}
