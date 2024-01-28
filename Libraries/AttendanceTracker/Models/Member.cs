using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MDRC.Data.Models
{
    [PrimaryKey(nameof(UniversityId))]
    public partial class Member : BaseEntity
    {
        [Key, Required]
        public int UniversityId { get; set; }
        [Required, StringLength(256)]
        public string GivenName { get; set; } = null!;
        [Required, StringLength(256)]
        public string FamilyName { get; set; } = null!;
        [Required, StringLength(256)]
        public string Email { get; set; } = null!;
        [Required]
        public bool IsActiveEboard { get; set; }
        [Required]
        public DateTimeOffset JoinDate { get; set; }
        public virtual List<ClubEventAttendee> ClubEventAttendees { get; } = new();
    }
}
