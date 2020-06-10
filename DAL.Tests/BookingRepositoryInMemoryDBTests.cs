using System;
using Xunit;
using vcs.DAL.Repositories.Impl;
using vcs.DAL.EF;
using Microsoft.EntityFrameworkCore;
using vcs.DAL.Entities;
using vcs.DAL.Repositories.Interfaces;
using System.Linq;

namespace DAL.Tests
{
    public class BookingRepositoryInMemoryDBTests
    {
        public BookingRoomNumberSystemContext Context => SqlLiteInMemoryContext();

        private BookingRoomNumberSystemContext SqlLiteInMemoryContext()
        {

            var options = new DbContextOptionsBuilder<BookingRoomNumberSystemContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            var context = new BookingRoomNumberSystemContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public void Create_InputBookingWithId0_SetBookingId1()
        {
            // Arrange
            int expectedListCount = 1;
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IBookingRepository repository = uow.Bookings;

            Booking Booking = new Booking(){ id = 1, firstname = "John", lastname = "Smith" };

            //Act
            repository.Create(Booking);
            uow.Save();
            var factListCount = context.Bookings.Count();

            // Assert
            Assert.Equal(expectedListCount, factListCount);
        }

        [Fact]
        public void Delete_InputExistBookingId_Removed()
        {
            // Arrange
            int expectedListCount = 0;
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IBookingRepository repository = uow.Bookings;
            Booking Booking = new Booking() { id = 1, firstname = "John", lastname = "Smith" };
            context.Bookings.Add(Booking);
            context.SaveChanges();

            //Act
            repository.Delete(Booking.id);
            uow.Save();
            var factBookingCount = context.Bookings.Count();

            // Assert
            Assert.Equal(expectedListCount, factBookingCount);
        }

        [Fact]
        public void Get_InputExistBookingId_ReturnBooking()
        {
            // Arrange
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IBookingRepository repository = uow.Bookings;
            Booking expectedBooking = new Booking() { id = 1, firstname = "John", lastname = "Smith" };
            context.Bookings.Add(expectedBooking);
            context.SaveChanges();

            //Act
            var factBooking = repository.Get(expectedBooking.id);

            // Assert
            Assert.Equal(expectedBooking, factBooking);
        }
    }
}
