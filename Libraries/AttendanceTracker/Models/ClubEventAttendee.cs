using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDRC.Data.Models
{
    [PrimaryKey(nameof(UniversityId), nameof(ClubEventId))]
    public class ClubEventAttendee : BaseEntity
    {
        [Key, Required, ForeignKey("Member")]
        public int UniversityId { get; set; }
        [Key, Required, ForeignKey("ClubEvent")]
        public Guid ClubEventId { get; set; }
        [Required]
        public DateTimeOffset SwipeDate { get; set; }
        public virtual Member Member { get; set; }

    }
}
