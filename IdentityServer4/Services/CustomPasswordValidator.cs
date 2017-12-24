using IdentityServer4.Models;
using IdentityServer4.Validation;
using IdentityServer.Host.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using QuickstartIdentityServer;
using IdentityServer.Host.Data;
using IdentityServer.Models.AccountModels;

namespace IdentityServer.Services
{
    public class CustomPasswordValidator : ICustomPasswordValidator
    {
        private readonly ILogger _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<AppSettings> _appSettingsAccessor;

        public CustomPasswordValidator(UserManager<ApplicationUser> userManager, ILoggerFactory loggerFactory, IOptions<AppSettings> appSettingsAccessor)
        {

            _userManager = userManager;
            _logger = loggerFactory.CreateLogger<AspNetIdentityResourceOwnerPasswordValidator>();
            _appSettingsAccessor = appSettingsAccessor;
        }

        // For development here are the resources:
        // https://stackoverflow.com/questions/35304038/identityserver4-register-userservice-and-get-users-from-database-in-asp-net-core
        // SHA1
        // https://stackoverflow.com/questions/4204993/how-to-get-a-equal-hash-to-the-formsauthentication-hashpasswordforstoringinconfi/12512795 

        // https://stackoverflow.com/questions/44979875/identityserver4-and-resourceownerpasswordvalidator-dynamic-connectionstring 

        // https://stackoverflow.com/questions/44979875/identityserver4-and-resourceownerpasswordvalidator-dynamic-connectionstring

        // Migrating users
        // http://travis.io/blog/2015/03/24/migrate-from-aspnet-membership-to-aspnet-identity/


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Example: TA's devadmin boulder1! - REMOVE BEFORE RELEASE?
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // This is a replica of the code and bicasemgmt stored procedure used by "membership" comparison found in login (forms authentication) for TA.
        //
        // Example: password: boulder1! -> with machine key + password all hashed sha1 -> 692DA675C456F5BAFEA982E69E59524E96970F46.
        //
        // Stored into the bicasemgmt.account.passwordhash table in a varbinary field.
        // [BICaseMgmt].[dbo].[Account].PassworHash - varbinary(max) = 0x36393244413637354334353646354241464541393832453639453539353234453936393730463436
        // hexidecimal string representing the binary that is stored in bicasemgmt.account.passwordhash.
        //
        // When the user was migrated the password was saved in the ASP.NET Identity database : dbo.ASPNetUsers.PasswordHash - nvarchar(max)
        //
        // 
        // '692DA675C456F5BAFEA982E69E59524E96970F46' this is the hex of the binary / hex
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<bool> ValidateAsync(string username, string password)
        {
            _logger.LogInformation("Password validation for user (" + username + ")");

            AppSettings appSettings = _appSettingsAccessor.Value;
            try
            {
                var user = await _userManager.FindByNameAsync(username);

                if (user == null)
                {
                    _logger.LogInformation("User (" + username + ") not found.");
                    return false;
                }

                // 1) We check the password in whatever format identityserver4 uses by default and return success/not. I'll look that up.
                if (await _userManager.CheckPasswordAsync(user, password))
                {
                    _logger.LogInformation("Password validated for user (" + username + ")");
                    return true;
                }

                // 2) We can check the ta migrated sha1 passwords. //
                // 2.1) User Input password
                var machinekeyTA = appSettings.TotalAccessMachineKey; // "1EF2A743319DEEA5F355CD442B0AA28AE2968F74AC3B3A692FA799860553B3FB398AE2A5A4B197E0BEA81A9EA53C21B3C34B8A42B242CAED97CAA80600A6B347";
                var passwordkey = machinekeyTA + password; // text password (example:boulder1!)

                // if the hashed password ends in "==" we can be sure it didn't come from legacy TA sha1.
                if (!(user.PasswordHash.Substring(Math.Max(0, user.PasswordHash.Length - 2)) == "=="))
                {
                    var algorithm = SHA1.Create();
                    var hashedPWDByteArray = algorithm.ComputeHash(Encoding.UTF8.GetBytes(passwordkey));

                    // BitConverter.ToString function gives me back a hexidecimal number in the format of 36-65-24...
                    string userEnteredHashedPWD = BitConverter.ToString(hashedPWDByteArray);
                    userEnteredHashedPWD = userEnteredHashedPWD.Replace("-", "");


                    // 2.2) Stored User password (try the legacy password) //
                    if (user.PasswordHash == userEnteredHashedPWD)// try the legacy password
                    {
                        _logger.LogDebug("Password validated SHA1 for user (" + username + ")");
                        return true;

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(3, "User password updated for user (" + username + ") " + ex.InnerException);
                return false;
            }
            return false;

        }
    }


}
