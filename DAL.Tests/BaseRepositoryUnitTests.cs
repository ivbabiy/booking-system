using System;
using Xunit;
using vcs.DAL.Repositories.Impl;
using vcs.DAL.EF;
using Microsoft.EntityFrameworkCore;
using vcs.DAL.Entities;
using vcs.DAL.Repositories.Interfaces;
using System.Linq;
using Moq;

namespace DAL.Tests
{
    class TestBookingRepository
        : BaseRepository<Booking>
    {
        public TestBookingRepository(DbContext context) 
            : base(context)
        {
        }
    }

    public class BaseRepositoryUnitTests
    {

        [Fact]
        public void Create_InputBookingInstance_CalledAddMethodOfDBSetWithBookingInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<BookingRoomNumberSystemContext>()
                .Options;
            var mockContext = new Mock<BookingRoomNumberSystemContext>(opt);
            var mockDbSet = new Mock<DbSet<Booking>>();
            mockContext
                .Setup(context => 
                    context.Set<Booking>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            var repository = new TestBookingRepository(mockContext.Object);

            Booking expectedBooking = new Mock<Booking>().Object;

            //Act
            repository.Create(expectedBooking);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedBooking
                    ), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<BookingRoomNumberSystemContext>()
                .Options;
            var mockContext = new Mock<BookingRoomNumberSystemContext>(opt);
            var mockDbSet = new Mock<DbSet<Booking>>();
            mockContext
                .Setup(context =>
                    context.Set<Booking>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IBookingRepository repository = uow.Bookings;
            var repository = new TestBookingRepository(mockContext.Object);

            Booking expectedBooking = new Booking() { id = 1, firstname = "John", lastname = "Smith" };
            mockDbSet.Setup(mock => mock.Find(expectedBooking.id)).Returns(expectedBooking);

            //Act
            repository.Delete(expectedBooking.id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedBooking.id
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedBooking
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<BookingRoomNumberSystemContext>()
                .Options;
            var mockContext = new Mock<BookingRoomNumberSystemContext>(opt);
            var mockDbSet = new Mock<DbSet<Booking>>();
            mockContext
                .Setup(context =>
                    context.Set<Booking>(
                        ))
                .Returns(mockDbSet.Object);

            Booking expectedBooking = new Booking() { id = 1, firstname = "John", lastname = "Smith" };
            mockDbSet.Setup(mock => mock.Find(expectedBooking.id))
                    .Returns(expectedBooking);
            var repository = new TestBookingRepository(mockContext.Object);

            //Act
            var actualBooking = repository.Get(expectedBooking.id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedBooking.id
                    ), Times.Once());
            Assert.Equal(expectedBooking, actualBooking);
        }

      
    }
}
