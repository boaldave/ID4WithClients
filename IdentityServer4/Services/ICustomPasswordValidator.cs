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
    public interface ICustomPasswordValidator
    {
        Task<bool> ValidateAsync(string username, string password);
    }


}
