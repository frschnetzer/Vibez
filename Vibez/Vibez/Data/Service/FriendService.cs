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

        public async Task AddFriend(ApplicationUser user)
        {
            try
            {
                Friend friend = new Friend()
                {
                    ApplicationUser = user,
                    ApplicationUserId = user.Id
                };

                //user.Friends.Add(friend);
                await _context.Friends.AddAsync(friend);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't add friend to database. See following exception: {ex}");
            }
        }

        public async Task<Friend> GetFriendByUser(ApplicationUser user)
        {
            try
            {
                return await _context.Friends.Where(x => x.ApplicationUser == user).Include(nameof(Friend.ApplicationUser)).FirstAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't get friend by id. See following exception: {ex}");
            }
        }

        public async Task<List<Friend>> GetAllFriendsByUser(ApplicationUser user)
        {
            try
            {
                return await _context.Friends.Where(e => e.ApplicationUser == user).Include(nameof(Friend.ApplicationUser)).ToListAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't get friends from user. See following exception: {ex}");
            }
        }

        public async Task RemoveFriendById(int friendId)
        {
            try
            {
                _context.Remove(await _context.Friends.Where(x => x.FriendId == friendId).FirstAsync());
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"Couldn't remove friend to database. See following exception: {ex}");
            }
        }
    }
}
