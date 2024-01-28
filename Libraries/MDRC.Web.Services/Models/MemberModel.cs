namespace MDRC.Models
{
    public class MemberModel
    {
        public int UniversityId { get; set; }

        public string GivenName { get; set; } = null!;

        public string FamilyName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string FullName => $"{GivenName} {FamilyName}";
    }
}