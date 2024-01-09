using Microsoft.AspNetCore.Identity;
using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public interface IApplicationUserService
    {
        Task<List<IdentityUser>> GetAllApplicationUsers();
        Task<IdentityUser> GetApplicationUserByEmail(string email);
    }
}