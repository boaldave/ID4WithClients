//using System;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
////using IdentityServer4.Quickstart.UI;
//using IdentityServer.Models.AccountModels;
//using IdentityModel.Client;
//using System.Net;
//using IdentityServer.Models.Login;
//using Microsoft.Extensions.Options;
//using QuickstartIdentityServer;
//using Microsoft.AspNetCore.Identity;
//using IdentityServer.Host.Models;
//using System.Linq;


//// At the moment it doesn't look like we need any of the services for this endpoint.
//namespace IdentityServer.Controllers
//{
//    [Authorize]
//    [SecurityHeaders]
//    public class LoginController : Controller
//    {

//        //private readonly UserManager<ApplicationUser> _userManager;
//        //private readonly SignInManager<ApplicationUser> _signInManager;
//        //private readonly IEmailSender _emailSender;
//        //private readonly ISmsSender _smsSender;
//        //private readonly ILogger _logger;
//        //private readonly IIdentityServerInteractionService _interaction;
//        //private readonly IClientStore _clientStore;
//        //private readonly AccountService _account;

//        //public LoginController(
//        //    UserManager<ApplicationUser> userManager,
//        //    SignInManager<ApplicationUser> signInManager,
//        //    IEmailSender emailSender,
//        //    ISmsSender smsSender,
//        //    ILoggerFactory loggerFactory,
//        //    IIdentityServerInteractionService interaction,
//        //    IHttpContextAccessor httpContext,
//        //    IClientStore clientStore)
//        //{
//        //_userManager = userManager;
//        //_signInManager = signInManager;
//        //_emailSender = emailSender;
//        //_smsSender = smsSender;
//        //_logger = loggerFactory.CreateLogger<AccountController>();
//        //_interaction = interaction;
//        //_clientStore = clientStore;

//        //_account = new AccountService(interaction, httpContext, clientStore);
//        //}


//        private readonly ILogger _logger;
//        private readonly IOptions<AppSettings> _appSettingsAccessor;
//        private readonly UserManager<ApplicationUser> _userManager;
//        public LoginController(IOptions<AppSettings> appSettingsAccessor, 
//                               ILoggerFactory loggerFactory, 
//                               UserManager<ApplicationUser> userManager)
//        {
//            _appSettingsAccessor = appSettingsAccessor;
//            _logger = loggerFactory.CreateLogger<AccountController>();
//            _userManager = userManager;
//        }



//        [HttpPost]
//        [AllowAnonymous]
//        [Route("api/login")]
//        public async Task<IActionResult> PostLogin([FromBody] LoginUserModel model)
//        {
//            _logger.LogInformation(1, "---- PostLogin Start (" + model.Username + ") ");
//            try
//            {
//                AppSettings appSettings = _appSettingsAccessor.Value;
//                string idserver = appSettings.IdentityServer;

//                var user = _userManager.Users.Where(u => u.UserName == model.Username).FirstOrDefault<ApplicationUser>();

//                if (user == null)
//                    return Json(new UserAccountResponse() { UpdateSucceeded = false, Error = "User not found." });

//                // Warning: If you have errors connecting to the discovery chances are they have to do with the signing certificate.
//                var disco = await DiscoveryClient.GetAsync(idserver);
//                if (disco.StatusCode != HttpStatusCode.OK)
//                    return Json(new LoginUserResponse() { LoginSucceeded = false, Error = "Error connecting to identity server discovery." });

//                var tokenEndpoint = idserver + "/connect/token";
//                var tokenClient = new TokenClient(tokenEndpoint, "taroclient", "secret");

//                var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(model.Username, model.Password);

//                // This is not an "error" to whatever applciation is calling. It's part of the process that there login attempt failed. 
//                if (tokenResponse.Error == "invalid_grant")
//                    return Json(new LoginUserResponse() { LoginSucceeded = false, Message = "Invalid user credentials." });

//                if (tokenResponse.IsError)
//                    return Json(new LoginUserResponse() { LoginSucceeded = false, Error = tokenResponse.Error });

//                var authResponse = new LoginUserResponse
//                {
//                    AccountId = user?.Id,
//                    AccessToken = tokenResponse.AccessToken,
//                    RefreshToken = tokenResponse.RefreshToken,
//                    LoginSucceeded = true,
//                    Message = "Here's your token!",
//                    PasswordExpirationDate = DateTime.MaxValue.ToString() // We do not set this value yet.
//                };

//                _logger.LogInformation(1, "User (" + model.Username + ") logged in.");

//                return Json(authResponse);

//            }
//            catch (Exception ex)
//            {
//                _logger.LogInformation(1, "Login Exception user(" + model.Username + ") " + ex.Message + " - " + ex.InnerException);
//                return Json(new LoginUserResponse() { LoginSucceeded = false, Error = "Error logging in." }); ;
//            }
//            finally
//            {
//                _logger.LogInformation(1, "---- PostLogin End (" + model.Username + ") ");

//            }
//        }
//    }
//}
