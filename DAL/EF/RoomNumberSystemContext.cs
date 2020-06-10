using vcs.DAL.Entities;
 using Microsoft.EntityFrameworkCore;
 using System;
 using System.Collections.Generic;
 using System.Text;

 namespace vcs.DAL.EF
 {
     public class BookingRoomNumberSystemContext
         : DbContext
     {
         public DbSet<Booking> Bookings { get; set; }
         public DbSet<RoomNumber> RoomNumbers { get; set; }

         public BookingRoomNumberSystemContext(DbContextOptions options)
             : base(options)
         {
         }

     }
 }