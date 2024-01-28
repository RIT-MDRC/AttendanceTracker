using MDRC.Data;
using MDRC.Models;
using MDRC.Services;
using MDRC.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Newtonsoft.Json;

namespace MDRC.Web.Controllers
{
    [Authorize]
    public class EmailsController : Controller
    {
        private readonly static string TEMPLATE_CHANGES_SAVED_MESSAGE = "The template's changes have been saved.";

        private readonly ILogger<SwipeController> _logger;
        private readonly MDRCSiteDbContext _siteContext;
        private readonly IEmailsService _emailsService;

        public EmailsController(ILogger<SwipeController> logger, MDRCSiteDbContext siteContext) //, ISwipeService swipeService)
        {
            _logger = logger;
            _siteContext = siteContext;
            _emailsService = new EmailsService(); // fix dependency injection...
            //_swipeService = swipeService;
        }

        private ILogger Logger => _logger;
        private MDRCSiteDbContext SiteContext => _siteContext;
        private IEmailsService EmailsService => _emailsService;

        public IActionResult Index(string warningMessage = "", string successMessage = "")
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetTemplateList()
        {
            return Json(new { data = EmailsService.GetTemplateList(SiteContext) });
        }

        public IActionResult EditEmailTemplate(Guid emailTemplateId)
        {
            return View(new EditEmailTemplateViewModel(EmailsService.GetEditEmailTemplateModel(SiteContext, emailTemplateId)));
        }

        [HttpPost]
        public JsonResult SaveEmailTemplate([FromForm] EmailTemplateModel emailTemplateModel)
        {
            EmailsService.SaveEmailTemplate(SiteContext, emailTemplateModel);

            return Json(new { Redirect = Url.Action("Index", "Emails", new { successMessage = Uri.EscapeDataString(TEMPLATE_CHANGES_SAVED_MESSAGE) }) });
        }

        public IActionResult GenerateEmail(Guid emailTemplateId)
        {
            return View(new GenerateEmailViewModel(EmailsService.GenerateEmail(SiteContext, int.Parse(User.Claims.FirstOrDefault(c => c.Type == "UniversityId")?.Value ?? "0"), emailTemplateId)));
        }

        public IActionResult GenerateEmailFromTemplate([FromForm] GenerateEmailModel generateEmailModel)
        {
            var generatedEmailContentViewModel = new GeneratedEmailContentViewModel(EmailsService.GenerateEmailFromTemplate(SiteContext, generateEmailModel));

            return View(generatedEmailContentViewModel);
        }

        public JsonResult SendEmail()
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                //Credentials = new NetworkCredential(Config.GetValue<string>("EmailUsername"), Config.GetValue<string>("EmailPassword")),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                //From = new MailAddress(Config.GetValue<string>("EmailUsername")),
                Subject = "test",
                //Body = Uri.UnescapeDataString(generatedEmailContentViewModel.EmailContent),
                IsBodyHtml = true,
            };
            mailMessage.To.Add("clintmhopkins@gmail.com");

            smtpClient.Send(mailMessage);

            return Json(new { IsSuccess = true }) ;
        }
    }
}