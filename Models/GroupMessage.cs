using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Circles_API.Models
{
    [Table("groupMessages")]
    public class GroupMessage
    {
        [Key]
        public int GroupMessageId { get; set; }
        public int CircleChatRoomId { get; set; }
        public int UserProfileId { get; set; }

        public string MessageText {get; set;}

        public ICollection<CircleUserprofile> Userprofiles { get; set; }
        // public virtual ApplicationUser Creator { get; set; }
    }
}