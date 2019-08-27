using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Circles_API.Models
{
    [Table("tags")]
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public string Name { get; set; }

        public ICollection<TagUserprofile> Userprofiles { get; set; }
    }
}