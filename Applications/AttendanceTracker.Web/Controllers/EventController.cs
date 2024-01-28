using MDRC.Data;
using MDRC.Data.Models;
using MDRC.Models;
using MDRC.Services;
using MDRC.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDRC.Web.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private static readonly string EVENT_CREATED_MESSAGE = "Event created sucessfully.";
        private static readonly string EVENT_DEACTIVATED_MESSAGE = "Event deleted sucessfully.";
        private static readonly string ATTENDANCE_RECORD_DEACTIVATED_MESSAGE = "Attendance record deleted sucessfully.";

        private readonly ILogger<SwipeController> _logger;
        private readonly MDRCSiteDbContext _siteContext;
        private readonly IEventService _eventService;

        public EventController(ILogger<SwipeController> logger, MDRCSiteDbContext siteContext) //, ISwipeService swipeService)
        {
            _logger = logger;
            _siteContext = siteContext;
            _eventService = new EventService(); // fix dependency injection...
            //_swipeService = swipeService;
        }

        private ILogger Logger => _logger;
        private MDRCSiteDbContext SiteContext => _siteContext;
        private IEventService EventService => _eventService;

        public IActionResult Index(string warningMessage = "", string successMessage = "")
        {
            return View();
        }

        public IActionResult CreateNewEvent(string successMessage = "")
        {
            return View(
                new AddUpdateEventViewModel
                {
                    AddUpdateEventModel = EventService.CreateNewEvent(successMessage)
                });
        }

        public IActionResult UpdateEvent(Guid eventId)
        {
            return View("CreateNewEvent",
                new AddUpdateEventViewModel
                {
                    AddUpdateEventModel = EventService.EditEvent(SiteContext, eventId)
                });
        }

        [HttpPost]
        public JsonResult SaveEvent([FromForm] AddUpdateEventModel createNewEventModel)
        {
            EventService.SaveEvent(SiteContext, createNewEventModel);

            return new JsonResult(new { Redirect = Url.Action("Index", "Event", new { successMessage = Uri.EscapeDataString(EVENT_CREATED_MESSAGE) }) });
        }

        [HttpGet]
        public JsonResult GetEventList()
        {
            return new JsonResult(new { data = EventService.GetEventList(SiteContext).Select(e => new EventViewModel(e)) }) ;
        }

        [HttpPost]
        public JsonResult DeactivateEvent(Guid eventId)
        {
            EventService.DeactivateEvent(SiteContext, eventId);

            return new JsonResult(new { successMessage = Uri.EscapeDataString(EVENT_DEACTIVATED_MESSAGE) });
        }

        [HttpGet]
        public IActionResult AttendeeList(Guid eventId)
        {
            return View(
                new AttendeeListViewModel
                {
                    EventId = eventId
                });
        }

        [HttpGet]
        public JsonResult GetAttendeeList(Guid eventId)
        {
            return new JsonResult(new { data = EventService.GetAttendeeList(SiteContext, eventId) });
        }

        [HttpPost]
        public IActionResult DeactivateAttendanceRecord(Guid eventId, int universityId)
        {
            EventService.DeactivateAttendanceRecord(SiteContext, eventId, universityId);

            return new JsonResult(new { successMessage = Uri.EscapeDataString(ATTENDANCE_RECORD_DEACTIVATED_MESSAGE) });
        }
    }
}