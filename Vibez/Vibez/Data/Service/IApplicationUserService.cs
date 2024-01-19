using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public interface IApplicationUserService
    {
        Task<List<ApplicationUser>> GetAllApplicationUsers();
        Task<ApplicationUser> GetApplicationUserByEmail(string email);
    }
}