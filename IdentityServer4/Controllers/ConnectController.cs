//using IdentityModel.Client;
//using IdentityServer.Host.Data;
//using IdentityServer.Host.Models;
//using IdentityServer.Models.AccountModels;
//using IdentityServer.Models.Authentication;

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
//using System.Net.Http;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;

//namespace IdentityServer.Controllers
//{
//	public class ConnectController : Controller
//    {
//        private readonly ILogger _logger;
//        private readonly IOptions<AppSettings> _appSettingsAccessor;

//        public ConnectController(ILoggerFactory loggerFactory,
//                                 IOptions<AppSettings> appSettingsAccessor)
//        {
//            _logger = loggerFactory.CreateLogger<AccountController>();
//            _appSettingsAccessor = appSettingsAccessor;
//        }

//        /// <summary>
//        /// Tries to get an access token for a trusted application.  The reason this connect is here is because the identity model did not work with the TA .net 4.0 code.
//        /// </summary>
//        /// <param name="credentials">The app's credentials (client type and secret) to send to the STS.</param>
//        /// <returns>A LoginResponse object with all the login info.</returns>
//        [HttpPost,
//		Route("api/connect")]
//		public async Task<IActionResult> PostConnect([FromBody] ClientCredentials credentials)
//		{
//            _logger.LogInformation("---- Connect - Started");
//			try
//			{
//                AppSettings appSettings = _appSettingsAccessor.Value;
//                string idserver = appSettings.IdentityServer;

//                // discover endpoints from metadata
//                var disco = await DiscoveryClient.GetAsync(idserver);

//                // request token
//                var tokenClient = new TokenClient(disco.TokenEndpoint, credentials.ClientType, credentials.Secret);
//                var tokenResponse = await tokenClient.RequestClientCredentialsAsync();

//                if (tokenResponse.IsError)
//                {
//                    _logger.LogInformation("---- Connect Error: " + tokenResponse.Error);
//                    return Json(new ClientCredentialsResponse() { Success = false });
//                    //return Json(tokenResponse);
//                }
//                return Json(new ClientCredentialsResponse() { Success = true, AccessToken = tokenResponse.AccessToken, TokenExpirationDate = DateTime.Now.AddSeconds(tokenResponse.ExpiresIn) });
//                //return Json(tokenResponse);
//			}
//            catch (Exception ex)
//            {
//                // We can return the exception on a client credentials call.
//                _logger.LogInformation("---- Connect Completed: " + ex.Message + " " + ex.InnerException);
//                return Json(new ClientCredentialsResponse() { Success = false, Error = ex.Message });
//            }
//            finally
//			{
//                _logger.LogInformation("---- Connect - Completed");
//            }
//        }
//	}
//}