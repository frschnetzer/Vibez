using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Vibez.Data.DTOs;
using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public class ApplicationUserService : IApplicationUserService
    {
        ApplicationDbContext context;

        public ApplicationUserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IdentityUser> GetApplicationUserByEmail(string email)
        {
            try
            {
                return await context.Users.Where(x => x.Email == email).SingleAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't get user by email. See following exception: {ex}");
            }
        }

        public async Task<List<IdentityUser>> GetAllApplicationUsers()
        {
            try
            {
                return await context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't get users. See following exception: {ex}");
            }
        }

        private async Task<bool> UserIsValid(string userName)
        {
            bool isDuplicate = await context.Users.AnyAsync(x => x.UserName == userName);

            if (!isDuplicate)
            {
                return false;
            }
            return true;
        }
    }
}
