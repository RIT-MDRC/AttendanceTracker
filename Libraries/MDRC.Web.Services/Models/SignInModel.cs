namespace MDRC.Models
{
    public class SignInModel
    {
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public bool RememberMe { get; set; }
    }
}