using Microsoft.EntityFrameworkCore;
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

        public async Task<ApplicationUser> GetApplicationUserByEmail(string email)
        {
            try
            {
                return await _context.Users
                    .Where(u => u.UserName == email)
                    .Include(x => x.Friends)
                    .Include(nameof(ApplicationUser.Events))
                    .FirstAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't get user by email. See following exception: {ex}");
            }
        }

        public async Task<List<ApplicationUser>> GetAllApplicationUsers()
        {
            try
            {
                return await _context.Users
                    .Include(nameof(ApplicationUser.Friends))
                    .Include(nameof(ApplicationUser.Events))
                    .ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't get users. See following exception: {ex}");
            }
        }
    }
}
