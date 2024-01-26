using System.ComponentModel.DataAnnotations;

namespace Vibez.Data.Models
{
    public class Friend
    {
        [Key]
        public int FriendId { get; set; }

        [Required]
        public string FriendEmail { get; set;  } = string.Empty;

        [Required]
        public string ApplicationUserId { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }
    }
}