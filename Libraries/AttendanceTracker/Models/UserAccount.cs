using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDRC.Data.Models
{
    [PrimaryKey(nameof(Username))]
    public partial class UserAccount : BaseEntity
    {
        [Key, Required, StringLength(256)]
        public string Username { get; set; } = null!;
        [Required, StringLength(256)]
        public string Password { get; set; } = null!;
        [Required, ForeignKey("Member")]
        public int MemberId { get; set; }
        public virtual Member Member { get; } = new();
    }
}
