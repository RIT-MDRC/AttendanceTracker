using MDRC.Data;
using MDRC.Data.Models;
using MDRC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace MDRC.Services
{
    public class EventService : BaseService, IEventService
    {
        private static readonly string NO_ACTIVE_EVENT_MESSAGE = "The selected event was already deleted. Please refresh and try your operation again.";
        private static readonly string NO_ACTIVE_ATTENDANCE_RECORD_MESSAGE = "The selected attendance record was already deleted. Please refresh and try your operation again.";

        public AddUpdateEventModel CreateNewEvent(string successMessage = "") 
            => new AddUpdateEventModel{ SuccessMessage = Uri.UnescapeDataString(successMessage) };

        public AddUpdateEventModel EditEvent(MDRCSiteDbContext siteContext, Guid eventId)
        {
            var clubEvent = siteContext.ClubEvents.First(ce => ce.IsActive && ce.ClubEventId == eventId);

            return new AddUpdateEventModel
            {
                EventId = eventId,
                EventName = clubEvent.Name,
                StartDate = clubEvent.StartDate,
                EndDate = clubEvent.EndDate,
                IsSwipeGranting = clubEvent.IsSwipeGranting
            };
        }

        public void SaveEvent(MDRCSiteDbContext siteContext, AddUpdateEventModel addUpdatEventModel)
        {
            if (addUpdatEventModel.EventId.HasValue)
            {
                var clubEvent = siteContext.ClubEvents.First(ce => ce.IsActive && ce.ClubEventId == addUpdatEventModel.EventId);
                clubEvent.StartDate = addUpdatEventModel.StartDate;
                clubEvent.EndDate = addUpdatEventModel.EndDate;
                clubEvent.IsSwipeGranting = addUpdatEventModel.IsSwipeGranting;
                clubEvent.Name = addUpdatEventModel.EventName;
            } 
            else
            {
                siteContext.ClubEvents.Add(new ClubEvent
                {
                    Name = addUpdatEventModel.EventName,
                    IsSwipeGranting = addUpdatEventModel.IsSwipeGranting,
                    IsActive = true,
                    StartDate = addUpdatEventModel.StartDate,
                    EndDate = addUpdatEventModel.EndDate
                });
            }

            siteContext.SaveChanges();
        }

        public List<EventModel> GetEventList(MDRCSiteDbContext siteContext)
        {
            return siteContext.ClubEvents.Where(ce => ce.IsActive).Select(ce => new EventModel
            {
                EventId = ce.ClubEventId,
                EventName = ce.Name,
                StartDate = ce.StartDate.ToLocalTime(),
                EndDate = ce.EndDate == null ? DateTimeOffset.MaxValue : ce.EndDate.Value.ToLocalTime(),
                IsSwipeGranting = ce.IsSwipeGranting
            }).ToList();
        }

        public void DeactivateEvent(MDRCSiteDbContext siteContext, Guid eventId)
        {
            var selectedEvent = siteContext.ClubEvents.Include(ce => ce.ClubEventAttendees).FirstOrDefault(e => e.IsActive && e.ClubEventId == eventId);

            if (selectedEvent == null)
            {
                throw new InvalidOperationException(NO_ACTIVE_EVENT_MESSAGE);
            }

            selectedEvent.IsActive = false;

            selectedEvent.ClubEventAttendees.Where(cea => cea.IsActive).ToList().ForEach(cea => cea.IsActive = false);

            siteContext.SaveChanges();
        }

        public List<AttendeeModel> GetAttendeeList(MDRCSiteDbContext siteContext, Guid eventId)
        {
            return siteContext.ClubEventAttendees
                .Include(cea => cea.Member)
                .Where(cea => cea.IsActive && cea.Member.IsActive && cea.ClubEventId == eventId)
                .Select(cea => new AttendeeModel
                {
                    UniversityId = cea.UniversityId,
                    EventId = eventId,
                    SwipeDate = cea.SwipeDate,
                    GivenName = cea.Member.GivenName,
                    FamilyName = cea.Member.FamilyName
                }).ToList();
        }

        public void DeactivateAttendanceRecord(MDRCSiteDbContext siteContext, Guid eventId, int universityId)
        {
            var selectedAttendanceRecord = siteContext.ClubEventAttendees.FirstOrDefault(cea => cea.IsActive && cea.ClubEventId == eventId && cea.UniversityId == universityId);

            if (selectedAttendanceRecord == null)
            {
                throw new InvalidOperationException(NO_ACTIVE_ATTENDANCE_RECORD_MESSAGE);
            }

            selectedAttendanceRecord.IsActive = false;

            siteContext.SaveChanges();
        }
    }
}
