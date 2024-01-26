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

        public async Task AddFriend(ApplicationUser currUser, ApplicationUser selectedFriend)
        {
            try
            {
                Friend friend = new Friend()
                {
                    ApplicationUser = currUser,
                    ApplicationUserId = currUser.Id,
                    FriendEmail = selectedFriend.Email
                };

                currUser.Friends.Add(friend);

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
        public async Task<List<ApplicationUser>> GetAllNonFriends(ApplicationUser currentUser)
        {
            try
            {
                var allUsersList = await _context.Users.Where(x => x.Id != currentUser.Id).ToListAsync();

                var friendList = await GetAllFriendsByUser(currentUser);
                List<ApplicationUser> friendsToApplicationList = new();

                foreach(var user in friendList)
                {
                    friendsToApplicationList.Add(allUsersList.Where(x => x.Email == user.FriendEmail).First());
                }

                return allUsersList.Except(friendsToApplicationList).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception($"Could not get all non friends: {ex.Message}");
            }
        }
    }
}
