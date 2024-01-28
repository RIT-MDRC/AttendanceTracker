using MDRC.Models;

namespace MDRC.Web.ViewModels
{
    public class EventViewModel
    {
        public EventViewModel(EventModel eventModel)
        {
            EventModel = eventModel;
        }

        public EventViewModel()
        {
            EventModel = new EventModel();
        }

        public EventModel EventModel { get; set; }

        public Guid EventId => EventModel.EventId;

        public string EventName => EventModel.EventName;

        public string IsSwipeGranting => EventModel.IsSwipeGranting ? "Yes" : "No";

        public string StartDate => EventModel.StartDate.ToLocalTime().ToString("O");

        public string EndDate => EventModel.EndDate.ToLocalTime().ToString("O");
    }
}