using System;
using System.Collections.Generic;
using System.Text;

namespace vcs.CCL.Security.Identity
{
    public abstract class User
    {
        public User(int i, string f, string l, string t)
        {
            id = i;
            firstname = f;
            lastname = l;
            type = t;
        }
        public int id { get; }
        public string firstname { get; }
        public string lastname { get; }
        protected string type { get; }
    }
}
