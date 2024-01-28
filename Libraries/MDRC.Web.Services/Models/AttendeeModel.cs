namespace MDRC.Models
{
    public class AttendeeModel : MemberModel
    {
        public Guid EventId { get; set; }
        public DateTimeOffset SwipeDate { get; set; }
    }
}