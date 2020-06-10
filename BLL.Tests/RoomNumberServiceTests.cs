using vcs.BLL.Services.Impl;
using vcs.BLL.Services.Interfaces;
using vcs.DAL.EF;
using vcs.DAL.Entities;
using vcs.DAL.Repositories.Interfaces;
using vcs.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using vcs.CCL.Security;
using vcs.CCL.Security.Identity;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace BLL.Tests
{
    public class RoomNumberServiceTests
    {

        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new RoomNumberService(nullUnitOfWork));
        }

        [Fact]
        public void GetRoomNumbers_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Admin(1, "William", "Brown");
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IRoomNumberService RoomNumberService = new RoomNumberService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => RoomNumberService.GetRoomNumbers(0));
        }

        [Fact]
        public void GetRoomNumbers_RoomNumberFromDAL_CorrectMappingToRoomNumberDTO()
        {
            // Arrange
            User user = new Admin(1, "James", "Davis");
            SecurityContext.SetUser(user);
            var recordService = GetRoomNumberService();

            // Act
            var actualRecordDto = recordService.GetRoomNumbers(0).First();

            // Assert
            Assert.True(actualRecordDto.id == 1);
        }

        IRoomNumberService GetRoomNumberService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var Booking = new Booking() { id = 123};
            var expectedRecord = new vcs.DAL.Entities.RoomNumber() { id = 1, Booking = Booking};
            var mockDbSet = new Mock<IRoomNumberRepository>();

            IRoomNumberService RoomNumberService = new RoomNumberService(mockContext.Object);

            return RoomNumberService;
        }
    }
}
