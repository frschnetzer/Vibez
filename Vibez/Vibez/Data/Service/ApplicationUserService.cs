using Microsoft.EntityFrameworkCore;
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

        public async Task UpdateUserNickName(ApplicationUser user)
        {
            try
            {
                if (await UserIsValid(user.UserName))
                {
                    var oldUser = await context.ApplicationUsers.FirstAsync(x => x.UserName == user.UserName);

                    oldUser.UserNickname = user.UserNickname;
                    oldUser.UserNicknameIdentifier = user.UserNicknameIdentifier;
 
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't update nickname. See following exception: {ex}");
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
