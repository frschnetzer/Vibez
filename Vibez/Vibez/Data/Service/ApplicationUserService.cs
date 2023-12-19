using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Vibez.Data.DTOs;
using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public class ApplicationUserService
    {
        ApplicationDbContext context;

        public ApplicationUserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ApplicationUser> GetApplicationUserByEmail(string email)
        {
            try
            {
                return await context.ApplicationUsers.Where(x => x.Email == email).SingleAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't get user by email. See following exception: {ex}");
            }
        }

        public async Task<List<ApplicationUser>> GetAllApplicationUsers()
        {
            try
            {
                return await context.ApplicationUsers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't get users. See following exception: {ex}");
            }
        }

        private async Task<bool> UserIsValid(string userName)
        {
            bool isDuplicate = await context.ApplicationUsers.AnyAsync(x => x.UserName == userName);

            if (!isDuplicate)
            {
                return false;
            }
            return true;
        }
    }
}
