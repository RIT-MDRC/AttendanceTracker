using System.Runtime.InteropServices;
using System.Web.Mvc;

namespace MDRC.Models
{
    public class AddUpdateEventModel : ErrorMesssageModel, IErrorHandlingModel
    {
        private DateTimeOffset? _startDate = null;

        private DateTimeOffset? _endDate = null;

        public Guid? EventId { get; set; }

        public string EventName { get; set; } = null!;

        public DateTimeOffset StartDate { 
            get
            {
                if (!_startDate.HasValue)
                {
                    var now = DateTime.SpecifyKind(DateTime.Today.AddDays(((int)DayOfWeek.Saturday - (int)DateTime.Today.DayOfWeek + 7) % 7).AddHours(14), DateTimeKind.Unspecified);

                    var to = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                            ? TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")
                            : TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
                    var offset = new DateTimeOffset(now, to.BaseUtcOffset);
                    _startDate = offset;
                }
                return _startDate.Value;
            }
            set => _startDate = value; }

        public DateTimeOffset? EndDate { 
            get 
            {
                if (!_endDate.HasValue)
                {
                    _endDate = StartDate.AddHours(2);
                }
                return _endDate.Value;
            }
            set => _endDate = value;
        }

        public bool IsSwipeGranting { get; set; }

        public override string ToString()
        {
            return $"EventName =\"{EventName}\" " +
                $"StartDate=\"{StartDate}\" " +
                $"EndDate=\"{EndDate}\" " +
                $"IsSwipeGranting=\"{IsSwipeGranting}\"";
        }
    }
}