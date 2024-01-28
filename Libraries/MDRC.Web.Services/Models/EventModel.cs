namespace MDRC.Models
{
    public class EventModel
    {
        public Guid EventId { get; set; }

        public string EventName { get; set; } = null!;

        public bool IsSwipeGranting { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }
    }
}