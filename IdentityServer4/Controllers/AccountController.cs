//using IdentityServer.Host.Data;
//using IdentityServer.Host.Models;
//using IdentityServer.Models.AccountModels;
//using IdentityServer4.Quickstart.UI;
//using IdentityServer4.Services;
//using IdentityServer4.Stores;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Options;
//using QuickstartIdentityServer;
//using System;
//using System.Linq;
//using System.Net;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;
//using static IdentityModel.OidcConstants;

//namespace IdentityServer.Controllers
//{
//    //[Authorize]
//    [SecurityHeaders] 
//    public class AccountController : Controller
//    {
//        private readonly UserManager<ApplicationUser> _userManager;
//        //private readonly SignInManager<ApplicationUser> _signInManager;
//        //private readonly IEmailSender _emailSender;
//        //private readonly ISmsSender _smsSender;
//        private readonly ILogger _logger;
//        private readonly IIdentityServerInteractionService _interaction;
//        private readonly IClientStore _clientStore;
//        private readonly AccountService _account;
//        private readonly PasswordHistoryDbContext _passwordHistoryDbContext;
//        private readonly IOptions<AppSettings> _appSettingsAccessor;
//        private AppSettings _appSettings {
//            get { return _appSettingsAccessor.Value; }
//        }

//        public AccountController(
//            UserManager<ApplicationUser> userManager,
//            SignInManager<ApplicationUser> signInManager,
//            //IEmailSender emailSender,
//            //ISmsSender smsSender,
//            ILoggerFactory loggerFactory,
//            IIdentityServerInteractionService interaction,
//            IHttpContextAccessor httpContext,
//            IClientStore clientStore,
//            PasswordHistoryDbContext passwordHistoryDbContext,  // Password History
//            IOptions<AppSettings> appSettingsAccessor)
//        {
//            _userManager = userManager;
//            //_signInManager = signInManager;
//            //_emailSender = emailSender;
//            //_smsSender = smsSender;
//            _logger = loggerFactory.CreateLogger<AccountController>();
//            _interaction = interaction;
//            _clientStore = clientStore;
//            _passwordHistoryDbContext = passwordHistoryDbContext;
//            _appSettingsAccessor = appSettingsAccessor;

//            _account = new AccountService(interaction, httpContext, clientStore);
//        }

        

//        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//        /// <summary>
//        /// Endpoints for the Account WEBAPI calls.
//        /// </summary>
//        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//        // [FromBody] on the parameter. This tells the framework to use the content-type header of the request to decide which of the configured IInputFormatters to use for model binding. 
//        [HttpPost]
//        [AllowAnonymous]
//        [Route("api/account/createaccount")]
//        public async Task<IActionResult> CreateUserAccount([FromBody] UserAccountModel model)
//        {
//            _logger.LogInformation(1, "---- CreateUserAccount Start (" + model.Username + ")");

//            try
//            {
//                var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
//                var result = await _userManager.CreateAsync(user, model.Password);

//                if (!result.Succeeded)
//                    return Json(new UserAccountResponse() { CreateSucceeded = false, Error = result.Errors.ToList().FirstOrDefault().Description });

//                // This would be information about the next step in the migration.
//                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
//                // Send an email with this link
//                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
//                //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
//                //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
//                //    $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");
//                //await _signInManager.SignInAsync(user, isPersistent: false);

//                _logger.LogInformation(1, "---- User created a new account with password.");

//                var newuser = _userManager.Users.Where(u => u.UserName == model.Username).FirstOrDefault<ApplicationUser>();

//                var authResponse = new UserAccountResponse
//                {
//                    Id = newuser.Id,
//                    Email = newuser.Email,
//                    CreateSucceeded = true,
//                    Message = "User account has been created."
//                };
//                return Json(authResponse);
//            }
//            catch( Exception ex)
//            {
//                _logger.LogInformation(3, "---- CreateUserAccount Exception: " + ex.Message + " " + ex.InnerException);
//                return Json(new UserAccountResponse() { CreateSucceeded = false, Error = "Error creating user account." });
//            }
//            finally
//            {
//                _logger.LogInformation(1, "---- CreateUserAccount Completed (" + model.Username + ")");
//            }

//        }


//        /// <summary>
//        /// The difference between transfer account and create account is that the raw sha1 password will be transfered and saved while we create the account. 
//        /// </summary>
//        /// <param name="model"></param>
//        /// <returns></returns>

//        [HttpPost]
//        [AllowAnonymous]
//        [Route("api/account/transferaccount")]
//        public async Task<IActionResult> TransferUserAccount([FromBody] UserAccountModel model)
//        {
//            _logger.LogInformation(1, "---- TransferUserAccount Start (" + model.Username + ")");

//            try
//            {
//                var userLookup = _userManager.Users.Where(u => u.UserName == model.Username).FirstOrDefault<ApplicationUser>();
//                if(userLookup != null)
//                    return Json(new UserAccountResponse() { CreateSucceeded = false, Error = "User already exists.", Id = userLookup.Id });

//                if (model.Username == null)
//                    return Json(new UserAccountResponse() { CreateSucceeded = false, Error = "Username was null." });
//                if (model.LegacyPasswordHash == null)
//                    return Json(new UserAccountResponse() { CreateSucceeded = false, Error = "Password was null." });

//                var createuser = new ApplicationUser { UserName = model.Username, Email = model.Email };

//                // Maybe we first create and then update the password to the legacy one.
//                var result = await _userManager.CreateAsync(createuser);
//                if (!result.Succeeded)
//                    return Json(new UserAccountResponse() { CreateSucceeded = false, Error = result.Errors.ToList().FirstOrDefault().Description });
                
//                _logger.LogInformation(1, "---- User created a new account with password.");

//                var user = _userManager.Users.Where(u => u.UserName == model.Username).FirstOrDefault<ApplicationUser>();
//                user.PasswordHash = model.LegacyPasswordHash;

//                var pwresult = await _userManager.UpdateAsync(user);

//                var authResponse = new UserAccountResponse
//                {
//                    Id = user.Id,
//                    CreateSucceeded = true,
//                    Message = "User account has been transfered."
//                };
//                return Json(authResponse);

//            }
//            catch (Exception ex)
//            {
//                _logger.LogInformation(3, "---- TransferUserAccount Endpoint Exception: " + ex.Message + " " + ex.InnerException);
//                return Json(new UserAccountResponse() { UpdateSucceeded = false, Error = "Error updating the user password." });
//            }
//            finally
//            {
//                _logger.LogInformation(1, "---- TransferUserAccount Completed (" + model.Username + ")");
//            }

//        }


//        /// https://stackoverflow.com/questions/20621950/asp-net-identity-default-password-hasher-how-does-it-work-and-is-it-secure
//        /// We update the user password on things like a reset password. We have? or don't need the current password so we update it to the temp.
//        [HttpPost]
//        [AllowAnonymous]
//        [Route("api/account/updatepassword")]
//        public async Task<IActionResult> UpdateUserPassword([FromBody] UserAccountModel model)
//        {
//            _logger.LogInformation(3, "---- UpdateUserPassword Start (" + model.Username + ")");

//            try
//            {
//                if (model.PasswordUpdate == null)
//                    return Json(new UserAccountResponse() { UpdateSucceeded = false, Error = "Error updating the user password." });


//                ApplicationUser user;

//                // The question is do I want to switch to the user id or not?
//                if (!string.IsNullOrEmpty(model.UserId))
//                    user = _userManager.Users.Where(u => u.Id == model.UserId).FirstOrDefault<ApplicationUser>();
//                else
//                    user = _userManager.Users.Where(u => u.UserName == model.Username).FirstOrDefault<ApplicationUser>();

//                if (user == null)
//                    return Json(new UserAccountResponse() { UpdateSucceeded = false, Error = "User not found." });


//                // Using ASP.NET Identity to hash the password correctly.
//                PasswordHasher<ApplicationUser> phasher = new PasswordHasher<ApplicationUser>();
//                var passwordHash = phasher.HashPassword(user, model.PasswordUpdate);

//                // Here, we've got the good one.
//                user.PasswordHash = passwordHash;


//                // Update the password history.
//                PasswordHistory passwordHistory = new PasswordHistory() { UserId = user.Id, PasswordHash = passwordHash, CreatedDate = DateTime.Now };
//                _passwordHistoryDbContext.Add<PasswordHistory>(passwordHistory);
//                _passwordHistoryDbContext.SaveChanges();

//                var pwHistCheckLimit = _appSettings.PasswordHistoryCheckLimit;
//                // Now we get all the passwords to see if we are storing too many for the rule.
//                var passwordsAll = _passwordHistoryDbContext.PasswordHistory
//                                    .Where(w => w.UserId == user.Id).OrderByDescending(pw => pw.CreatedDate)
//                                    .ToList<PasswordHistory>();

//                // We should clear out the history that is not relavent.
//                if (passwordsAll.Count > pwHistCheckLimit)
//                {
//                    passwordsAll.RemoveRange(0, pwHistCheckLimit); // These are the excess we don't care to compare.
//                    _passwordHistoryDbContext.PasswordHistory.RemoveRange(passwordsAll);
//                    _passwordHistoryDbContext.SaveChanges();
//                }


//                // And we save it.
//                var result = await _userManager.UpdateAsync(user);

//                if (!result.Succeeded)
//                    return Json(new UserAccountResponse() { UpdateSucceeded = false, Error = result.Errors.ToList().FirstOrDefault().Description });

//                _logger.LogInformation(3, "---- User password updated for user: " + model.Username);

//                var authResponse = new UserAccountResponse
//                {
//                    Id = user.Id,
//                    UpdateSucceeded = true,
//                    Message = "User password has been changed."
//                };
//                return Json(authResponse);
 
//            }
//            catch (Exception ex)
//            {
//                _logger.LogInformation(3, "---- UpdateUserPassword Endpoint Exception: " + ex.Message + " " + ex.InnerException);
//                return Json(new UserAccountResponse() { UpdateSucceeded = false, Error = "Error updating the user password." });
//            }
//            finally
//            {
//                _logger.LogInformation(3, "---- UpdateUserPassword Completed (" + model.Username + ")");
//            }
//        }



//        /// https://stackoverflow.com/questions/20621950/asp-net-identity-default-password-hasher-how-does-it-work-and-is-it-secure
//        /// We change the user password giving the old and new passwords.  Requires looking at the history and all that jazz.
//        [HttpPost]
//        //[AllowAnonymous]
//        [Route("api/account/changepassword")]
//        public async Task<IActionResult> ChangeUserPassword([FromBody] UserAccountModel model)
//        {
//            _logger.LogInformation(3, "---- ChangeUserPassword Start (" + model.Username + ")");

//            try
//            {
//                // We'll need them both current and new passwords.
//                if (model.PasswordUpdate == null || model.Password == null)
//                    return Json(new UserAccountResponse() { UpdateSucceeded = false, Error = "Error updating the user password." });
                
//                ApplicationUser user;

//                // The question is do I want to switch to the user id or not?
//                if (!string.IsNullOrEmpty(model.UserId))
//                    user = _userManager.Users.Where(u => u.Id == model.UserId).FirstOrDefault<ApplicationUser>();
//                else
//                    user = _userManager.Users.Where(u => u.UserName == model.Username).FirstOrDefault<ApplicationUser>();

//                if (user == null)
//                    return Json(new UserAccountResponse() { UpdateSucceeded = false, Error = "User not found." });


//                // Using ASP.NET Identity to hash the password correctly to compare against the history list.
//                PasswordHasher<ApplicationUser> phasher = new PasswordHasher<ApplicationUser>();
//                var passwordHash = phasher.HashPassword(user, model.PasswordUpdate);

//                // Let's check the password history.                   
//                // Now... Get all the passwords changes related to this user. 
//                var pwHistCheckLimit = _appSettings.PasswordHistoryCheckLimit;
//                var passwords = _passwordHistoryDbContext.PasswordHistory
//                                    .Where(w => w.UserId == user.Id).OrderByDescending(pw => pw.CreatedDate)
//                                    .Take(pwHistCheckLimit) // Whatever the history rule is.
//                                    .ToList<PasswordHistory>();


//                // Then we compare using the verifyhashpassword method because it's smart enough to figure out what the salt was.
//                foreach (var password in passwords)
//                {
//                    PasswordVerificationResult itIsTheSame = phasher.VerifyHashedPassword(user, password.PasswordHash, model.PasswordUpdate);
//                    if (itIsTheSame == PasswordVerificationResult.Success)
//                        return Json(new UserAccountResponse() { UpdateSucceeded = false, Message = "Password previously used." });
//                }


//                // We are compairing the current password.
//                // This is difficult because of the two seperate hashing algorithms between IdentitServer and TA.
//                // This code should notibly be a service.
//                // if the hashed password ends in "==" we can be sure it didn't come from legacy TA sha1.
//                if (!(user.PasswordHash.Substring(Math.Max(0, user.PasswordHash.Length - 2)) == "=="))
//                {
//                    var machinekeyTA = _appSettings.TotalAccessMachineKey; // Legacy TA machine key stored in the app settings.
//                    var password = machinekeyTA + model.Password; // text password (example:boulder1!)


//                    var algorithm = SHA1.Create();
//                    var hashedPWDByteArray = algorithm.ComputeHash(Encoding.UTF8.GetBytes(password));

//                    // BitConverter.ToString function gives me back a hexidecimal number in the format of 36-65-24...
//                    string userEnteredHashedPWD = BitConverter.ToString(hashedPWDByteArray);
//                    userEnteredHashedPWD = userEnteredHashedPWD.Replace("-", "");

//                    // Stored User password (try the legacy password) //
//                    string hexString = user.PasswordHash;

//                    byte[] hexBytes = Enumerable.Range(0, hexString.Length)
//                                        .Where(x => x % 2 == 0)
//                                        .Select(x => Convert.ToByte(hexString.Substring(x, 2), 16))
//                                        .ToArray();

//                    string taHashedPWD = System.Text.Encoding.UTF8.GetString(hexBytes);

//                    if (taHashedPWD != userEnteredHashedPWD)// try the legacy password
//                    {
//                        _logger.LogDebug("Password validated SHA1 for user (" + model.Username + ")");

//                        return Json(new UserAccountResponse() { UpdateSucceeded = false, Message = "Password was not valid." });
//                    }
//                }
//                else  // Else we'll try the default way.
//                {
//                    IdentityResult changePasswordResult = _userManager.ChangePasswordAsync(user, model.Password, model.PasswordUpdate).Result;

//                    if (!changePasswordResult.Succeeded) // We tried.
//                        return Json(new UserAccountResponse() { UpdateSucceeded = false, Message = "Password was not valid." });
//                }

                    

//                // Save the changes in the password history.
//                PasswordHistory passwordHistory = new PasswordHistory() { UserId = user.Id, PasswordHash = passwordHash, CreatedDate = DateTime.Now };
//                _passwordHistoryDbContext.Add<PasswordHistory>(passwordHistory);
//                _passwordHistoryDbContext.SaveChanges();

//                // Now we get all the passwords to see if we are storing too many for the rule.
//                var passwordsAll = _passwordHistoryDbContext.PasswordHistory
//                                    .Where(w => w.UserId == user.Id).OrderByDescending(pw => pw.CreatedDate)
//                                    .ToList<PasswordHistory>();

//                // We should clear out the history that is not relavent.
//                if (passwordsAll.Count > pwHistCheckLimit)
//                {
//                    passwordsAll.RemoveRange(0, pwHistCheckLimit); // These are the excess we don't care to compare.
//                    _passwordHistoryDbContext.PasswordHistory.RemoveRange(passwordsAll);
//                    _passwordHistoryDbContext.SaveChanges();
//                }

//                _logger.LogInformation(3, "---- User password updated for user: " + model.Username);

//                var authResponse = new UserAccountResponse
//                {
//                    Id = user.Id,
//                    UpdateSucceeded = true,
//                    Message = "User password has been changed."
//                };
//                return Json(authResponse);

//            }
//            catch (Exception ex)
//            {
//                _logger.LogInformation(3, "---- UpdateUserPassword Endpoint Exception: " + ex.Message + " " + ex.InnerException);
//                return Json(new UserAccountResponse() { UpdateSucceeded = false, Error = "Error updating the user password." });
//            }
//            finally
//            {
//                _logger.LogInformation(3, "---- ChangeUserPassword Completed (" + model.Username + ")");
//            }
//        }


//        [HttpPost]
//        //[AllowAnonymous]
//        //[Authorize(Policy = "Over21")]
//        [Authorize]
//        //[Authorize(ActiveAuthenticationSchemes = "Bearer")]
//        [Route("api/account/updateusername")]
//        public async Task<IActionResult> UpdateUsername([FromBody] UserAccountModel model)
//        {
//            _logger.LogInformation(3, "UpdateUsername Start  (" + model?.Username + ")");

//            if (model.UsernameUpdate == null)
//                return Json(new UserAccountResponse() { UpdateSucceeded = false, Error = "Error updating the user name." });
            
//            try
//            { 
//                IdentityResult result;
//                ApplicationUser user;
//                // The question is do I want to switch to the user id or not?
//                if (!string.IsNullOrEmpty(model.UserId))
//                    user = _userManager.Users.Where(u => u.Id == model.UserId).FirstOrDefault<ApplicationUser>();
//                else
//                    user = _userManager.Users.Where(u => u.UserName == model.Username).FirstOrDefault<ApplicationUser>();

//                if (user == null)
//                    return Json(new UserAccountResponse() { UpdateSucceeded = false, Error = "User not found." });

//                user.UserName = model.UsernameUpdate;
//                user.NormalizedUserName = model.UsernameUpdate.ToUpper();

//                result = await _userManager.UpdateAsync(user);
//                if (!result.Succeeded)
//                    return Json(new UserAccountResponse() { UpdateSucceeded = false, Error = result.Errors.ToList().FirstOrDefault().Description });

//                _logger.LogInformation(3, "Username updated for user: " + model.Username);

//                var authResponse = new UserAccountResponse
//                {
//                    UpdateSucceeded = true,
//                    Message = "Username has been changed."

//                };
//                return Json(authResponse);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogInformation(3, "---- UpdateUsername Endpoint Exception: " + ex.Message + " " + ex.InnerException);
//                return Json(new UserAccountResponse() { UpdateSucceeded = false, Error = "Error updating the user name." });
//            }
//            finally
//            {
//                _logger.LogInformation(3, "UpdateUsername Completed  (" + model?.Username + ")");
//            }
//        }


//        [HttpPost]
//        [AllowAnonymous]
//        [Route("api/account/useraccountinfo")]
//        public async Task<IActionResult> UserAccountInfo([FromBody] UserAccountModel model)
//        {
//            _logger.LogInformation(3, "---- UserAccountInfo Start (" + model?.Username + ")");

//            UserAccountResponse userAccountResponse = null;

//            if (model == null)
//                return Json(new UserAccountResponse() { Message = "Username was null.", Error = "Username was null." });

//            try
//            {
//                ApplicationUser user;
//                // The question is do I want to switch to the user id or not?
//                if (!string.IsNullOrEmpty(model.UserId))
//                    user = _userManager.Users.Where(u => u.Id == model.UserId).FirstOrDefault<ApplicationUser>();
//                else
//                    user = _userManager.Users.Where(u => u.UserName == model.Username).FirstOrDefault<ApplicationUser>();

//                if (user == null)
//                    return Json(new UserAccountResponse() { Error = "User not found." });

//                userAccountResponse = new UserAccountResponse
//                {
//                    Id = user.Id,
//                    Email = user.Email
//                };
//            }
//            catch (Exception ex)
//            {
//                _logger.LogInformation(3, "---- UserAccountInfo Endpoint Exception: " + ex.Message + " " + ex.InnerException);
//                return Json(new UserAccountResponse() { Error = "There was an error in the authentication server." });
//            }

//            _logger.LogInformation(3, "---- UserAccountInfo Completed (" + model?.Username + ")");

//            return Json(userAccountResponse);
//        }

    

//    }
//}
