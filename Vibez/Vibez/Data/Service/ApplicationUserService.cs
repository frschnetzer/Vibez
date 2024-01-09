using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vibez.Data.DTOs;
using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public class ApplicationUserService : IApplicationUserService
    {
        ApplicationDbContext _context;

        public ApplicationUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IdentityUser> GetApplicationUserByEmail(string email)
        {
            try
            {
                return await _context.Users.Where(x => x.Email == email).SingleAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't get user by email. See following exception: {ex}");
            }
        }

        public async Task<List<IdentityUser>> GetAllApplicationUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't get users. See following exception: {ex}");
            }
        }

        private async Task<bool> UserIsValid(string userName)
        {
            bool isDuplicate = await _context.Users.AnyAsync(x => x.UserName == userName);

            if(!isDuplicate)
            {
                return false;
            }
            return true;
        }
    }
}
