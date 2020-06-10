using vcs.DAL.Entities;
 using vcs.DAL.Repositories.Interfaces;
 using System;
 using System.Collections.Generic;
 using System.Text;

 namespace vcs.DAL.UnitOfWork
 {
     public interface IUnitOfWork : IDisposable
     {
         IBookingRepository Bookings { get; }
         IRoomNumberRepository RoomNumbers { get; }
         void Save();
     }
 }