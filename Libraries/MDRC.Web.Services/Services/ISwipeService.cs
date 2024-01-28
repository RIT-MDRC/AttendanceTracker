using MDRC.Data;
using MDRC.Models;

namespace MDRC.Services
{
    public interface ISwipeService
    {
        /// <summary>
        /// Grabs the active club event and unescapes any messages.
        /// </summary>
        /// <param name="siteContext">The database holding the active club events</param>
        /// <param name="warningMessage">Optional: An escaped warning message to be shown to the user</param>
        /// <param name="successMessage">Optional: An escaped success message to be shown to the user</param>
        /// <returns></returns>
        public SwipeModel Index(MDRCSiteDbContext siteContext, string warningMessage = "", string successMessage = "");

        /// <summary>
        /// Creates an attendance record for the user if possible. Otherwise, sets up the data for a new member form.
        /// </summary>
        /// <param name="siteContext">The database holding the attendance records and members</param>
        /// <param name="swipeRequest">The data for the attendance record</param>
        /// <returns></returns>
        public CreateNewMemberModel CreateSwipeRecord(MDRCSiteDbContext siteContext, SwipeModel swipeRequest);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteContext"></param>
        /// <param name="createNewMemberModel"></param>
        /// <returns></returns>
        public CreateNewMemberModel CreateNewMember(MDRCSiteDbContext siteContext, CreateNewMemberModel createNewMemberModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="successMessage"></param>
        /// <returns></returns>
        public AddUpdateEventModel CreateNewEvent(string successMessage = "");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="successMessage"></param>
        /// <returns></returns>
        public ManualEntryModel ManualEntry(MDRCSiteDbContext siteContext, Guid? eventId, string successMessage = "", string warningMessage = "");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteContext"></param>
        /// <param name="createNewEventModel"></param>
        public void SaveNewEvent(MDRCSiteDbContext siteContext, AddUpdateEventModel createNewEventModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteContext"></param>
        /// <param name="eventId"></param>
        public EventModel GetEventTimes(MDRCSiteDbContext siteContext, Guid eventId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteContext"></param>
        /// <param name="swipeRequest"></param>
        /// <param name="requestorUniversityId"></param>
        public void CreateAuditedSwipeRecord(MDRCSiteDbContext siteContext, SwipeModel swipeRequest, int requestorUniversityId);

    }
}
