using System.ComponentModel.DataAnnotations;

namespace Circles_API.Models
{
    public class CircleChatRoomUserprofile
    {
        public int CircleChatRoomUserprofileId { get; set; }
        public int CircleChatRoomId { get; set; }
        public int UserprofileId { get; set; }

        public virtual CircleChatRoomUserprofile circleChatRoom { get; set; }
        public virtual Userprofile Userprofile { get; set; }
    }
}