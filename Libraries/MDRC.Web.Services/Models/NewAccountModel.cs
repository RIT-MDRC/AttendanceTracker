namespace MDRC.Models
{
    public class NewAccountModel
    {
        public int UniversityId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}