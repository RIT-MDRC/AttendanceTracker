using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDRC.Data.Models
{
    [PrimaryKey(nameof(ProjectId), nameof(MemberId))]
    public class ProjectMember : BaseEntity
    {
        [Key, Required]
        public int ProjectId { get; set; }
        [Key, Required, ForeignKey("Member")]
        public int MemberId { get; set; }
        [Required]
        public DateTimeOffset JoinDate { get; set; }

        public virtual Project Project { get; } = new();

        public virtual Member Member { get; } = new();
    }
}
