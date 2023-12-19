using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public interface IApplicationUserService
    {
        Task UpdateUserNickName(ApplicationUser user);
        Task<ApplicationUser> GetApplicationUserByEmail(string email);

    }
}