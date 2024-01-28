using MDRC.Data;
using MDRC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MDRC.Web.ViewModels;

namespace MDRC.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly string ACCOUNT_CREATED_MESSAGE = "Your account was created sucessfully, please sign in to continue.";
        private readonly string EXISTING_UID_MESSAGE = "An account was already created for this UID, please login below or contact an EBoard member if this is an error.";
        private readonly string INVALID_CREDENTIALS_MESSAGE = "The username or password provided is invalid";
        private readonly string TRY_AGAIN_MESSAGE = "Something went wrong. Please try again.";
        private readonly string SIGNED_OUT_MESSAGE = "You have successfully signed out.";

        private readonly ILogger<AccountController> _logger;
        private readonly MDRCSiteDbContext _siteContext;
        private readonly Services.IAuthenticationService _authenticationService;

        public AccountController(ILogger<AccountController> logger, MDRCSiteDbContext siteContext) //, ISignInService signInService)
        {
            _logger = logger;
            _siteContext = siteContext;
            _authenticationService = new Services.AuthenticationService();
            //_signInService = signInService;
        }

        private ILogger Logger => _logger;
        private MDRCSiteDbContext SiteContext => _siteContext;
        private Services.IAuthenticationService AuthenticationService => _authenticationService;

        public async Task<IActionResult> Login(string successMessage = "", string warningMessage = "", string errorMessage = "")
        {
            // Clear the existing external cookie
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
        
            return View(new ErrorMesssageViewModel
                {
                    ErrorMesssageModel = AuthenticationService.Login(successMessage, warningMessage, errorMessage)
                });
        }
        public async Task<IActionResult> SignedOut()
        {
            var errorMessage = string.Empty;
            var successMessage = string.Empty;
            try
            {
                // Clear the existing external cookie
                await HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
                successMessage = SIGNED_OUT_MESSAGE;

            } catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.ToString());
                errorMessage = ex.Message;
            }

            return RedirectToAction("Login", AuthenticationService.CreateErrorMessagePayload(successMessage: successMessage, errorMessage: errorMessage));
        }

        public IActionResult CreateAccount(int universityId)
        {
            try
            {
                return View(new CreateAccountViewModel {
                    CreateAccountModel = AuthenticationService.CreateAccount(SiteContext, universityId)
                });
            }
            catch (InvalidDataException ex)
            {
                Logger.Log(LogLevel.Warning, ex.ToString());
                return RedirectToAction("Login",  AuthenticationService.CreateErrorMessagePayload(warningMessage: EXISTING_UID_MESSAGE));
            }
        }

        [HttpPost]
        public JsonResult CreateNewAccount([FromBody] NewAccountModel newAccount)
        {
            if (string.IsNullOrWhiteSpace(newAccount.Username) || string.IsNullOrWhiteSpace(newAccount.Password)) 
            {
                throw new InvalidDataException(INVALID_CREDENTIALS_MESSAGE);
            }

            AuthenticationService.CreateNewAccount(SiteContext, newAccount);

            return new JsonResult(
                new
                {
                    Redirect = Url.Action("Login", AuthenticationService.CreateErrorMessagePayload(successMessage: ACCOUNT_CREATED_MESSAGE))
                });
        }

        [HttpGet]
        public async Task<JsonResult> Submit(SignInModel signInRequest)
        {
            if (signInRequest == null)
            {
                Logger.Log(LogLevel.Error, "The signInRequest was null.");
                return new JsonResult(
                    new
                    {
                        Redirect = Url.Action("Login", AuthenticationService.CreateErrorMessagePayload(warningMessage: TRY_AGAIN_MESSAGE))
                    });
            }

            var authenticationModel = AuthenticationService.Submit(SiteContext, signInRequest);

            if (authenticationModel == null)
            {
                return new JsonResult(
                    new
                    {
                        Redirect = Url.Action("Login", AuthenticationService.CreateErrorMessagePayload(errorMessage: INVALID_CREDENTIALS_MESSAGE))
                    });
            }

            var authScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            await HttpContext.SignInAsync(
                authScheme,
                new ClaimsPrincipal(new ClaimsIdentity(authenticationModel.Claims, authScheme)),
                new AuthenticationProperties { IsPersistent = authenticationModel.IsPersistent });

            return new JsonResult(new { Redirect = Url.Action("Index", "Home") });
        }
    }
}