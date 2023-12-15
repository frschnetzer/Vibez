using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vibez.Data.Models
{
    public class ApplicationUser : IdentityUser
    {

        [StringLength(50)]
        public string UserNickname { get; set; } = string.Empty;

        [StringLength(6)]
        public string UserNicknameIdentifier { get; set; } = string.Empty;

        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
