using MDRC.Data;
using MDRC.Data.Models;
using MDRC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace MDRC.Services
{
    public class SwipeService : BaseService, ISwipeService
    {
        private static readonly string BAD_PARSE_MESSAGE = "The value \"{0}\" could not be parsed.";
        private static readonly string EXISTING_UID_MESSAGE = "Could not create new member - The UID \"{0}\" already exists.";
        private static readonly string NO_DB_CHANGES_MESSAGE = "No changes were made to the DB.";
        private static readonly string ATTENDANCE_RECORD_EXISTS = "This event already has an attendace record for the member.";
        private static readonly string GENERIC_ERROR_MESSAGE = "An error occured, the issue was logged. Please inform a E-Board member or try again.";


        public SwipeModel Index(MDRCSiteDbContext siteContext, string warningMessage = "", string successMessage = "")
        {
            var currentEvent = siteContext.ClubEvents.FirstOrDefault(ce => ce.IsActive && ce.StartDate <= DateTimeOffset.Now && DateTimeOffset.Now <= ce.EndDate);
            return new SwipeModel
            {
                WarningMessage = warningMessage,
                SuccessMessage = successMessage,
                EventId = currentEvent?.ClubEventId,
                EventName = currentEvent?.Name ?? string.Empty
            };
        }

        public CreateNewMemberModel CreateSwipeRecord(MDRCSiteDbContext siteContext, SwipeModel swipeRequest)
        {
            if (!swipeRequest.EventId.HasValue)
            {
                throw new InvalidDataException(string.Format(GENERIC_ERROR_MESSAGE, swipeRequest.SwipeReading));
            }

            if (!swipeRequest.UniversityId.HasValue)
            {
                throw new InvalidDataException(string.Format(BAD_PARSE_MESSAGE, swipeRequest.SwipeReading));
            }

            var member = siteContext.Members.SingleOrDefault(m => m.UniversityId == swipeRequest.UniversityId && m.IsActive);

            if (member == null)
                return new CreateNewMemberModel
                {
                    UniversityId = swipeRequest.UniversityId.Value,
                    EventId = swipeRequest.EventId.Value
                };

            var inactiveRecord = siteContext.ClubEventAttendees.SingleOrDefault(cea => cea.UniversityId == swipeRequest.UniversityId
                && cea.ClubEventId == swipeRequest.EventId && !cea.IsActive);

            if (inactiveRecord != null)
            {
                inactiveRecord.IsActive = true;
                inactiveRecord.SwipeDate = swipeRequest.SwipeDate;
                siteContext.SaveChanges();
            }
             else if (!siteContext.ClubEventAttendees.Any(cea => cea.UniversityId == swipeRequest.UniversityId
                && cea.ClubEventId == swipeRequest.EventId))
            {
                siteContext.ClubEventAttendees.Add(new ClubEventAttendee
                {
                    UniversityId = swipeRequest.UniversityId.Value,
                    ClubEventId = swipeRequest.EventId.Value,
                    SwipeDate = swipeRequest.SwipeDate,
                    IsActive = true
                });
                siteContext.SaveChanges();
            }

            return new CreateNewMemberModel
            {
                GivenName = member.GivenName,
                FamilyName = member.FamilyName
            };
        }

        public AddUpdateEventModel CreateNewEvent(string successMessage = "") 
            => new AddUpdateEventModel{ SuccessMessage = Uri.UnescapeDataString(successMessage) };

        public CreateNewMemberModel CreateNewMember(MDRCSiteDbContext siteContext, CreateNewMemberModel createNewMemberModel)
        {
            if (siteContext.Members.Any(m => m.UniversityId == createNewMemberModel.UniversityId))
            {
                throw new InvalidDataException(string.Format(EXISTING_UID_MESSAGE, createNewMemberModel.UniversityId));
            }

            siteContext.Members.Add(new Member
            {
                GivenName = createNewMemberModel.GivenName,
                FamilyName = createNewMemberModel.FamilyName,
                Email = createNewMemberModel.Email,
                UniversityId = createNewMemberModel.UniversityId,
                JoinDate = createNewMemberModel.IsNewMember ? DateTimeOffset.Now : new DateTimeOffset(2000, 1, 1, 0, 0, 0, DateTimeOffset.Now.Offset),
                IsActiveEboard = false,
                IsActive = true
            });

            siteContext.ClubEventAttendees.Add(new ClubEventAttendee
            {
                ClubEventId = createNewMemberModel.EventId,
                UniversityId = createNewMemberModel.UniversityId,
                SwipeDate = DateTimeOffset.Now,
                IsActive = true
            });

            if (siteContext.SaveChanges() == 0)
            {
                throw new SystemException(NO_DB_CHANGES_MESSAGE);
            }

            return new CreateNewMemberModel
            {
                GivenName = createNewMemberModel.GivenName,
                FamilyName = createNewMemberModel.FamilyName
            };

        }
        public ManualEntryModel ManualEntry(MDRCSiteDbContext siteContext, Guid? eventId, string successMessage = "", string warningMessage = "")
        {
            var eventList = siteContext.ClubEvents.Where(ce => ce.IsActive).OrderByDescending(ce => ce.StartDate).Select(ce => new EventModel
            {
                EventId = ce.ClubEventId,
                EventName = ce.Name,
            }).ToList();

            var memberList = siteContext.Members.Where(m => m.IsActive).OrderBy(m => m.GivenName).ThenBy(m => m.FamilyName).Select(m => new MemberModel
            {
                GivenName = m.GivenName,
                FamilyName = m.FamilyName,
                UniversityId = m.UniversityId
            }).ToList();

            return new ManualEntryModel
            {
                SuccessMessage = successMessage,
                WarningMessage = warningMessage,
                EventId = eventId,
                EventList = eventList,
                MemberList = memberList
            };
        }

        public void SaveNewEvent(MDRCSiteDbContext siteContext, AddUpdateEventModel createNewEventModel)
        {
            siteContext.ClubEvents.Add(new ClubEvent
            {
                Name = createNewEventModel.EventName,
                IsSwipeGranting = createNewEventModel.IsSwipeGranting,
                IsActive = true,
                StartDate = createNewEventModel.StartDate,
                EndDate = createNewEventModel.EndDate
            });

            siteContext.SaveChanges();
        }

        public EventModel GetEventTimes(MDRCSiteDbContext siteContext, Guid eventId)
        {
            var selectedEvent = siteContext.ClubEvents.Single(ce => ce.ClubEventId == eventId);

            return new EventModel
            {
                EventId = eventId,
                StartDate = selectedEvent.StartDate.ToLocalTime(),
                EndDate = selectedEvent.EndDate?.ToLocalTime() ?? DateTimeOffset.MaxValue
            };
        }

        public void CreateAuditedSwipeRecord(MDRCSiteDbContext siteContext, SwipeModel swipeRequest, int requestorUniversityId)
        {
            CreateSwipeRecord(siteContext, swipeRequest);

            // TODO: create audit logic
        }

    }
}
