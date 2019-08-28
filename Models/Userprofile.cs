using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Circles_API.Models
{
    [Table("userprofiles")]
    public class Userprofile
    {
        [Key]
        public int UserprofileId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Bio { get; set; }
        public string Photo { get; set; }
        public string Location { get; set; }

        // public ICollection<TagUserprofile> Tags { get; set; }
        // public virtual ICollection<CircleUserprofile> Circles { get; set; }
        // public virtual ApplicationUser ApplicationUser { get; set; }
    }
}