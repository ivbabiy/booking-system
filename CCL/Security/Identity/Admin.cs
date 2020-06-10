using System;
using System.Collections.Generic;
using System.Text;

namespace vcs.CCL.Security.Identity
{
    public class Admin
        : User
    {
        public Admin(int id, string firstname, string lastname)
            : base(id, firstname, lastname, nameof(Admin))
        {
        }
    }
}
