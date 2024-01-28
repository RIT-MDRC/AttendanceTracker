using MDRC.Data;
using MDRC.Data.Models;
using MDRC.Models;
using MDRC.Services;
using MDRC.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MDRC.Web.Controllers
{
    public class SwipeController : Controller
    {
        private static readonly string GENERIC_ERROR_MESSAGE = "An error occured, the issue was logged. Please inform a E-Board member or try again.";
        private static readonly string BAD_SWIPE_MESSAGE = "Bad swipe, please try again.";
        private static readonly string EVENT_CREATED_MESSAGE = "Event created sucessfully.";
        private static readonly string ATTENDANCE_SAVED_MESSAGE = "Attendance record sucessfully saved.";

        private readonly ILogger<SwipeController> _logger;
        private readonly MDRCSiteDbContext _siteContext;
        private readonly ISwipeService _swipeService;

        public SwipeController(ILogger<SwipeController> logger, MDRCSiteDbContext siteContext) //, ISwipeService swipeService)
        {
            _logger = logger;
            _siteContext = siteContext;
            _swipeService = new SwipeService(); // fix dependency injection...
            //_swipeService = swipeService;
        }

        private ILogger Logger => _logger;
        private MDRCSiteDbContext SiteContext => _siteContext;
        private ISwipeService SwipeService => _swipeService;

        public IActionResult Index(string warningMessage = "", string successMessage = "")
        {
            return View(new SwipeViewModel
            {
                SwipeModel = SwipeService.Index(SiteContext, warningMessage, successMessage)
            });
        }

        [HttpPost]
        public IActionResult CreateSwipeRecord(SwipeModel swipeRequest)
        {
            Logger.Log(LogLevel.Information, $"Creating attendance record for {swipeRequest}");

            try
            {
                return View(new CreateNewMemberViewModel {
                    CreateNewMemberModel = SwipeService.CreateSwipeRecord(SiteContext, swipeRequest)
                });
            } catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.ToString());
                return RedirectToAction("Index", new { warningMessage = Uri.EscapeDataString(BAD_SWIPE_MESSAGE) });
            }
        }

        [Authorize]
        public IActionResult CreateNewEvent(string successMessage = "")
        {
            return View(
                new AddUpdateEventViewModel
                {
                    AddUpdateEventModel = SwipeService.CreateNewEvent(successMessage)
                });
        }

        [Authorize]
        public IActionResult ManualEntry(Guid? eventId, string successMessage = "", string warningMessage = "")
        {
            return View(
                new ManualEntryViewModel
                {
                    ManualEntryModel = SwipeService.ManualEntry(SiteContext, eventId, successMessage, warningMessage),
                    RequesterUniversityId = int.Parse(HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "UniversityId")?.Value ?? "999999999")
                }) ;
        }

        [HttpPost]
        public IActionResult CreateNewMember (CreateNewMemberModel createNewMemberModel)
        {
            Logger.Log(LogLevel.Information, $"Creating new member {createNewMemberModel.NewMemberToString()}");

            try
            {
                return View("CreateSwipeRecord", new CreateNewMemberViewModel(SwipeService.CreateNewMember(SiteContext, createNewMemberModel)));
            }
            catch (Exception ex)
            {
                if (ex is InvalidDataException)
                {
                    Logger.Log(LogLevel.Error, ex.ToString());
                }
                else
                {
                    Logger.Log(LogLevel.Error, $"Unable to create member or create attendance record for {createNewMemberModel}" +
                        $"\n {ex}");
                }

                return RedirectToAction("Index", new { warningMessage = Uri.EscapeDataString(GENERIC_ERROR_MESSAGE) });
            }
        }

        [HttpPost]
        [Authorize]
        public JsonResult SaveNewEvent([FromForm] AddUpdateEventModel createNewEventModel)
        {
            SwipeService.SaveNewEvent(SiteContext, createNewEventModel);

            return new JsonResult(new { Redirect = Url.Action("CreateNewEvent", "Swipe", new { successMessage = Uri.EscapeDataString(EVENT_CREATED_MESSAGE) }) });
        }

        [HttpGet]
        [Authorize]
        public JsonResult GetEventTimes(Guid eventId)
        {
            return new JsonResult(SwipeService.GetEventTimes(SiteContext, eventId));
        }

        [HttpPost]
        [Authorize]
        public JsonResult CreateManualEntry([FromForm] ManualEntryViewModel manualEntryViewModel)
        {
            try
            {
                SwipeService.CreateAuditedSwipeRecord(SiteContext, manualEntryViewModel.SwipeModel, manualEntryViewModel.RequesterUniversityId);
            }
            catch (InvalidOperationException ex)
            {
                Logger.Log(LogLevel.Warning, ex.ToString());
                return new JsonResult(new { Redirect = Url.Action("ManualEntry", "Swipe", new { warningMessage = Uri.EscapeDataString(ex.Message) }) });
            }

            return new JsonResult(
                new {
                    Redirect = Url.Action("ManualEntry", "Swipe", 
                    new 
                    { 
                        successMessage = Uri.EscapeDataString(ATTENDANCE_SAVED_MESSAGE), 
                        eventId = manualEntryViewModel.EventId
                    }) 
                });
        }
    }
}