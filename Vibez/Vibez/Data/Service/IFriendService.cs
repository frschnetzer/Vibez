using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public interface IFriendService
    {
        Task AddFriend(ApplicationUser currUser, ApplicationUser selectedFriend);
        Task<List<Friend>> GetAllFriendsByUser(ApplicationUser user);
        Task<Friend> GetFriendByUser(ApplicationUser user);
        Task RemoveFriendById(int friendId);
    }
}