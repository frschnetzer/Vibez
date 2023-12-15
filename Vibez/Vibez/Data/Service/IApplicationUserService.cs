using Vibez.Data.DTOs;
using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public interface IApplicationUserService
    {
        Task<List<ApplicationUser>> GetAllApplicationUsers();
        Task<ApplicationUser> GetApplicationUserByEmail(string email);
        Task<ApplicationUserDTO> GetApplicationUserDTO(ApplicationUser applicationUser);
        Task UpdateUserNickName(ApplicationUser user);
    }
}