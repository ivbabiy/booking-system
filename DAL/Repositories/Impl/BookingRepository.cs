using System;
using System.Collections.Generic;
using System.Text;
using vcs.DAL.Entities;
using vcs.DAL.Repositories.Interfaces;
using vcs.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace vcs.DAL.Repositories.Impl
{
    public class BookingRepository
        : BaseRepository<Booking>, IBookingRepository
    {

        internal BookingRepository(BookingRoomNumberSystemContext context) 
            : base(context)
        {
        }
    }
}
