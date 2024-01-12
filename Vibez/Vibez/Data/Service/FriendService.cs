using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public class FriendService : IFriendService
    {
        ApplicationDbContext _context;

        public FriendService(ApplicationDbContext context)
        {
            _context = context;
        }
     
        public async Task AddFriend(IdentityUser user)
        {
            try
            {
                await _context.Friends.AddAsync(new Friend()
                {
                    User = user,
                });

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't add friend to database. See following exception: {ex}");
            }
        }
         
        public async Task<Friend> GetFriendByUser(IdentityUser user)
        {
            try
            {
                return await _context.Friends.Where(x => x.User == user).FirstAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't get friend by id. See following exception: {ex}");
            }
        }

        public async Task<List<Friend>> GetAllFriendsByUser(IdentityUser user)
        {
            try
            {
                return await _context.Friends.Where(e => e.User == user).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't get friends from user. See following exception: {ex}");
            }
        }

        public async Task RemoveFriend(Friend friend)
        {
            try
            {
                _context.Remove(friend);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't remove friend to database. See following exception: {ex}");
            }
        }
    }
}
