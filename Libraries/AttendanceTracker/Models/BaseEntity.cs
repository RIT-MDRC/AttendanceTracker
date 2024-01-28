using System.ComponentModel.DataAnnotations;

namespace MDRC.Data.Models
{
    public class BaseEntity
    {
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
