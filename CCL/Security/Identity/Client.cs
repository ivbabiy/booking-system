using System;
using System.Collections.Generic;
using System.Text;

namespace vcs.CCL.Security.Identity
{
    public class Client
        : User
    {
        public Client(int id, string firstname, string lastname)
            : base(id, firstname, lastname, nameof(Client))
        {
        }
    }
}
