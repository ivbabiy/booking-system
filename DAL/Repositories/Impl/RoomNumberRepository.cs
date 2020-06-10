using System;
 using System.Collections.Generic;
 using System.Text;
 using vcs.DAL.Entities;
 using vcs.DAL.Repositories.Interfaces;
 using Microsoft.EntityFrameworkCore;
 using vcs.DAL.EF;
 using System.Linq;

 namespace vcs.DAL.Repositories.Impl
 {
     public class RoomNumberRepository
         : BaseRepository<RoomNumber>, IRoomNumberRepository
     {
         internal RoomNumberRepository(BookingRoomNumberSystemContext context) 
             : base(context)
         {
         }
     }
 }