using Microsoft.EntityFrameworkCore;
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

        public async Task UpdateUserNickName(ApplicationUser user)
        {
            try
            {
                if(await UserIsValid(user.UserName))
                {
                    var oldUser = await context.ApplicationUsers.FirstAsync(x => x.UserName == user.UserName);

                    oldUser.UserNickname = user.UserNickname;
                    oldUser.UserNicknameIdentifier = user.UserNicknameIdentifier;

                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't update nickname. See following exception: {ex}");
            }
        }

        public async Task<ApplicationUser> GetApplicationUserByEmail(string email)
        {
            try
            {
                return await context.Users.Where(x => x.UserName == email).Select(x => new ApplicationUser()
                {
                    UserName = x.UserName,
                    AccessFailedCount = x.AccessFailedCount,
                    ConcurrencyStamp = x.ConcurrencyStamp,
                    Email = x.Email,
                    EmailConfirmed = x.EmailConfirmed,
                    Id = x.Id,
                    LockoutEnabled = x.LockoutEnabled,
                    LockoutEnd = x.LockoutEnd,
                    NormalizedEmail = x.NormalizedEmail,
                    NormalizedUserName = x.NormalizedUserName,
                    PasswordHash = x.PasswordHash,
                    PhoneNumberConfirmed = x.PhoneNumberConfirmed,
                    PhoneNumber = x.PhoneNumber,
                    SecurityStamp = x.SecurityStamp,
                    TwoFactorEnabled = x.TwoFactorEnabled
                }).FirstAsync();
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
                return await context.ApplicationUsers.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't get users. See following exception: {ex}");
            }
        }

        public async Task<ApplicationUserDTO> GetApplicationUserDTO(ApplicationUser applicationUser)
        {
            try
            {
                return await context.ApplicationUsers
                    .Where(x => x.Email == applicationUser.Email)
                    .Select(x => new ApplicationUserDTO
                    {
                        UserNickname = applicationUser.UserNickname,
                        UserNicknameIdentifier = applicationUser.UserNicknameIdentifier
                    }).FirstAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't get userDTO. See following exception: {ex}");
            }
        }

        private async Task<bool> UserIsValid(string userName)
        {
            bool isDuplicate = await context.ApplicationUsers.AnyAsync(x => x.UserName == userName);

            if(!isDuplicate)
            {
                return false;
            }
            return true;
        }
    }
}
