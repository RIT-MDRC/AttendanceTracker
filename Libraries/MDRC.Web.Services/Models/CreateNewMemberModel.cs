namespace MDRC.Models
{
    public class CreateNewMemberModel
    {
        public string GivenName { get; set; } = null!;
        public string FamilyName { get; set; } = null!;
        public int UniversityId { get; set; }
        public string Email { get; set; } = null!;
        public Guid EventId { get; set; }
        public bool IsNewMember { get; set; } = true;

        public string NewMemberToString()
        {
            return $"GivenName =\"{GivenName}\" " +
                $"FamilyName=\"{FamilyName}\" " +
                $"Email=\"{Email}\" " +
                $"UniversityId=\"{UniversityId}\" " +
                $"IsNewMember=\"{IsNewMember}\"";
        }

        public string AttendenceRecordToString()
        {
            return $"EventId=\"{EventId}\"" +
                $"EventId=\"{UniversityId}\"" +
                $"RecordTime=\"{DateTimeOffset.UtcNow}\"";
        }

        public override string ToString()
        {
            return NewMemberToString() + "\nat\n" + AttendenceRecordToString();
        }
    }
}