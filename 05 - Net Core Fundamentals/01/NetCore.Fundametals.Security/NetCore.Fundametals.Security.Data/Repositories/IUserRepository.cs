using NetCore.Fundamentals.Security.Data.Model;

namespace NetCore.Fundamentals.Security.Data.Repositories
{
    public interface IUserRepository
    {
        User GetByGoogleId(string googleId);
        User GetByUsernameAndPassword(string username, string password);
    }
}