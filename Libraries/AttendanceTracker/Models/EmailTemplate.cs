using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MDRC.Data.Models
{
    [PrimaryKey(nameof(EmailTemplateId))]
    public partial class EmailTemplate : BaseEntity
    {
        [Key, Required]
        public Guid EmailTemplateId { get; set; }
        [Required, StringLength(256)]
        public string Name { get; set; } = null!;
        [Required, StringLength(int.MaxValue)]
        public string TemplateText { get; set; } = null!;
    }
}
