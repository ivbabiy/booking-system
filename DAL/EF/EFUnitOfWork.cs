using vcs.DAL.Entities;
 using vcs.DAL.Repositories.Impl;
 using vcs.DAL.Repositories.Interfaces;
 using vcs.DAL.UnitOfWork;
 using Microsoft.EntityFrameworkCore;
 using System;

 namespace vcs.DAL.EF
 {
     public class EFUnitOfWork
         : IUnitOfWork
     {
         private BookingRoomNumberSystemContext db;
         private BookingRepository BookingRepository;
         private RoomNumberRepository RoomNumberRepository;

         public EFUnitOfWork(BookingRoomNumberSystemContext context)
         {
             db = context;
         }
         public IBookingRepository Bookings
         {
             get
             {
                 if (BookingRepository == null)
                     BookingRepository = new BookingRepository(db);
                 return BookingRepository;
             }
         }

         public IRoomNumberRepository RoomNumbers
         {
             get
             {
                 if (RoomNumberRepository == null)
                     RoomNumberRepository = new RoomNumberRepository(db);
                 return RoomNumberRepository;
             }
         }

         public void Save()
         {
             db.SaveChanges();
         }

         private bool disposed = false;

         public virtual void Dispose(bool disposing)
         {
             if (!this.disposed)
             {
                 if (disposing)
                 {
                     db.Dispose();
                 }
                 this.disposed = true;
             }
         }

         public void Dispose()
         {
             Dispose(true);
             GC.SuppressFinalize(this);
         }
     }
 }