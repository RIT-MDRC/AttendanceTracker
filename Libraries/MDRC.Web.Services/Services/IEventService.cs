using MDRC.Data;
using MDRC.Models;

namespace MDRC.Services
{
    public interface IEventService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="successMessage"></param>
        /// <returns></returns>
        public AddUpdateEventModel CreateNewEvent(string successMessage = "");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteContext"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public AddUpdateEventModel EditEvent(MDRCSiteDbContext siteContext, Guid eventId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteContext"></param>
        /// <param name="createNewEventModel"></param>
        public void SaveEvent(MDRCSiteDbContext siteContext, AddUpdateEventModel createNewEventModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteContext"></param>
        public List<EventModel> GetEventList (MDRCSiteDbContext siteContext);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteContext"></param>
        /// <param name="eventId"></param>
        public void DeactivateEvent(MDRCSiteDbContext siteContext, Guid eventId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteContext"></param>
        /// <param name="eventId"></param>
        public List<AttendeeModel> GetAttendeeList(MDRCSiteDbContext siteContext, Guid eventId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteContext"></param>
        /// <param name="eventId"></param>
        /// <param name="universityId"></param>
        public void DeactivateAttendanceRecord(MDRCSiteDbContext siteContext, Guid eventId, int universityId);
    }
}
