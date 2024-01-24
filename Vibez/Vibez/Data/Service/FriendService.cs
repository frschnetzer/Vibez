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
                return await _context.Friends
                    .Where(x => x.ApplicationUser == user)
                    .Include(nameof(Friend.ApplicationUser))
                    .FirstAsync();
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
                return await _context.Friends
                    .Where(e => e.ApplicationUser == user)
                    .Include(nameof(Friend.ApplicationUser))
                    .ToListAsync();
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

        /// <summary>
        /// Get a list of all users that are not friends with the current user
        /// </summary>
        /// <param name="currentUser">Current authenticated user</param>
        /// <returns>List of Friend</returns>
        /// <exception cref="Exception">Throws when an error occures while reading from database</exception>
        public async Task<List<Friend>> GetAllNonFriends(ApplicationUser currentUser)
        {
            try
            {
                var friendList = await GetAllFriendsByUser(currentUser);

                var allUsersList = await _context.Users.Where(x => x.Id != currentUser.Id).ToListAsync();

                List<Friend>? allUsersToFriendsList = new();

                foreach(var item in allUsersList)
                {
                    allUsersToFriendsList.Add(new Friend()
                    {
                        ApplicationUser = item,
                        ApplicationUserId = item.Id,
                    });
                }

                return allUsersToFriendsList.Except(friendList).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception($"Could not get all non friends: {ex.Message}");
            }
        }
    }
}
