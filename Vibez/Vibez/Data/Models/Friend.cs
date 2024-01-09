using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vibez.Data.Models
{
    public class Friend
    {
        [Key]
        public int FriendId { get; set; }
        
        public IdentityUser User { get; set; }
    }
}
