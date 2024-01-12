using Microsoft.AspNetCore.Identity;
using Vibez.Data.Models;

namespace Vibez.Data.Service
{
    public interface IFriendService
    {
        Task AddFriend(IdentityUser user);
        Task<List<Friend>> GetAllFriendsByUser(IdentityUser user);
        Task<Friend> GetFriendByUser(IdentityUser user);
        Task RemoveFriend(Friend friend);
    }
}