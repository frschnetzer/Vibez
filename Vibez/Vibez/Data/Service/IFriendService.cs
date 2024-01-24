using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public interface IFriendService
    {
        Task AddFriend(ApplicationUser user);
        Task<List<Friend>> GetAllFriendsByUser(ApplicationUser user);
        Task<List<Friend>> GetAllNonFriends(ApplicationUser currentUser);
        Task<Friend> GetFriendByUser(ApplicationUser user);
        Task RemoveFriendById(int friendId);
    }
}