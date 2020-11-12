using NetCore.Fundamentals.Security.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Fundamentals.Security.Data.Repositories
{
    public interface IUserRepository
    {
        User GetByUsernameAndPassword(string username, string password);
        User GetByGoogleId(string googleId);
    }
}
