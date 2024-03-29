using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Circles_API.Models
{
    [Table("circles")]
    public class Circle
    {
        [Key]
        public int CircleId { get; set; }
        public string Name { get; set; }
        public string ApplicationUserId { get; set; }

        public ICollection<CircleUserprofile> Userprofiles { get; set; }
        // public virtual ApplicationUser Creator { get; set; }
    }
}