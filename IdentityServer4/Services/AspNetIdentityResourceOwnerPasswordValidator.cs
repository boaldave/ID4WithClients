using IdentityServer.Host.Models;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class AspNetIdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly ILogger _logger;
        private readonly ICustomPasswordValidator _customPasswordValidator;
        private readonly UserManager<ApplicationUser> _userManager;
        public AspNetIdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager, ICustomPasswordValidator customPasswordValidator, ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _customPasswordValidator = customPasswordValidator;
            _logger = loggerFactory.CreateLogger<AspNetIdentityResourceOwnerPasswordValidator>();
        }


        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            _logger.LogInformation("Resource Owner Password validation for user (" + context.UserName + ")");

            var user = await _userManager.FindByNameAsync(context.UserName);
            if(user==null)
                context.Result = new GrantValidationResult(TokenRequestErrors.UnauthorizedClient, "invalid user credentials."); 

            bool validated = await _customPasswordValidator.ValidateAsync(context.UserName, context.Password);
  
            if (validated)
            {
                context.Result = new GrantValidationResult(
                    subject: user.Id.ToString(),
                    authenticationMethod: "custom",
                    claims: new List<Claim> { new Claim("Role", "unknown") });
            }
            else
                context.Result = new GrantValidationResult(TokenRequestErrors.UnauthorizedClient, "invalid user credentials.");

            return;

        }
    }


}
