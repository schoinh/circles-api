using System.ComponentModel.DataAnnotations;

namespace Circles_API.Models
{
    public class CircleUserprofile
    {
        public int CircleUserprofileId { get; set; }
        public int CircleId { get; set; }
        public int UserprofileId { get; set; }

        // public virtual Circle Circle { get; set; }
        public virtual Userprofile Userprofile { get; set; }
    }
}