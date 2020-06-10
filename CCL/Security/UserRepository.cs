using vcs.DAL.Repositories.Interfaces;
using vcs.DAL.EF;
using vcs.CCL.Security.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace vcs.DAL.Repositories.Impl
{
    public class UserRepository
         : BaseRepository<User>
    {
        public UserRepository(BookingRoomNumberSystemContext context) : base(context)
        {
        }
    }
}
