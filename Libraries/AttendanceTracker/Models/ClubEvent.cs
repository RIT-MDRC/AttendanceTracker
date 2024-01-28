using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDRC.Data.Models
{
    [PrimaryKey(nameof(ClubEventId))]
    public class ClubEvent : BaseEntity
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClubEventId { get; set; }
        [Required, StringLength(512)]
        public string Name { get; set; } = null!;
        [Required]
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        [Required]
        public bool IsSwipeGranting { get; set; }
        public virtual List<ClubEventAttendee> ClubEventAttendees { get; } = new();
    }
}
