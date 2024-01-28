using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDRC.Data.Models
{
    [PrimaryKey(nameof(ProjectId))]
    public class Project : BaseEntity
    {
        [Key, Required]
        public Guid ProjectId { get; set; }
        [Required, StringLength(256)]
        public string Name { get; set; } = null!;
        [Required, ForeignKey("Member")]
        public int TeamLeadId { get; set; }
        public virtual List<ProjectMember> ProjectMembers { get; } = new();
    }
}
