using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Vibez.Data.Models
{
    public class ApplicationUser:IdentityUser
    {

        [Required]
        [StringLength(50)]
        public string UserNickname { get; set; } = string.Empty;

        [Required]
        [StringLength(6)]
        public string UserNicknameIdentifier { get; set; } = string.Empty;
    }
}
