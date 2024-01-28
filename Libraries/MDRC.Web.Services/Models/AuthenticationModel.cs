using System.Security.Claims;

namespace MDRC.Models
{
    public class AuthenticationModel
    {
        public List<Claim> Claims { get; set; } = null!;
        public bool IsPersistent { get; set; }
    }
}