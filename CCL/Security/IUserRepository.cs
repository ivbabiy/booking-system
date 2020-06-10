using vcs.DAL.Entities;
using vcs.DAL.Repositories.Interfaces;
using vcs.CCL.Security.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace vcs.DAL.Repositories.Interfaces
{
    public interface IUserRepository
        : IRepository<User>
    {
    }
}
