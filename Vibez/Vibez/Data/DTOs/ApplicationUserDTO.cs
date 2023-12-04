using System.ComponentModel.DataAnnotations;

namespace Vibez.Data.DTOs
{
    public class ApplicationUserDTO
    {
        public string UserNickname { get; set; } = string.Empty;
        public string UserNicknameIdentifier { get; set; } = string.Empty;
    }
}
