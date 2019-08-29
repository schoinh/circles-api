using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Circles_API.Models
{
    [Table("CircleChatRooms")]
    public class CircleChatRoom
    {
        [Key]
        public int CircleChatRoomId { get; set; }

        //public int OwnerId {get; set;}
        public string Name { get; set; }

        public virtual List<GroupMessageProfile> userProfiles {get; set;}

        public virtual List<GroupMessages> groupMessages {get; set;}

    }
}

//issue: creater of circle not automatically in the circle.  How to add them to their circle chat?

/*
steps:
create chat room: chatroom controller: create, passes in circle id, passes in userid then in form hidden field, then next create redirects to chatroom 
add users to group, 


 */