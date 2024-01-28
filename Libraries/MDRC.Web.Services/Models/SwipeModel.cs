namespace MDRC.Models
{
    public class SwipeModel : ErrorMesssageModel, IErrorHandlingModel
    {
        private int? _universityId;
        private DateTimeOffset? _swipeTime;

        public string EventName { get; set; } = null!;

        public string SwipeReading { get; set; } = null!;

        public int? UniversityId { 
            get
            {
                if (!_universityId.HasValue)
                {
                    if (SwipeReading == null || SwipeReading.Length < 10)
                        return null;

                    if (int.TryParse(SwipeReading.Substring(1, 9), out int parsedReading))
                        _universityId = parsedReading;
                    else
                        return null;
                }

                return _universityId.Value;
            } 
            set
            {
                _universityId = value;
            }
        }

        public Guid? EventId { get; set; }

        public DateTimeOffset SwipeDate
        {
            get
            {
                if (!_swipeTime.HasValue)
                    _swipeTime = DateTimeOffset.Now;
                return _swipeTime.Value;
            }
            set => _swipeTime = value;
        }

        public override string ToString()
        {
            try
            {
                return $"SwipeReading=\"{SwipeReading}\" " +
                    $"UniversityId=\" {UniversityId}\" " +
                    $"EventId=\"{EventId}\" " +
                    $"SwipeDate=\"{DateTimeOffset.Now}\"";
            } catch (Exception ex)
            {
                throw new Exception($"Could not process the swipe model. Exception: {ex}\n{ex.StackTrace}");
            }
        }
    }
}