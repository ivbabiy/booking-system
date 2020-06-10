using System;
using System.Collections.Generic;
using System.Text;
using vcs.DAL.Entities;

namespace vcs.BLL.DTO
{
    public class RoomNumberDTO
    {
        public int id { get; set; }
        public Booking booking { get; set; }
    }
}
