using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models.Authentication
{
    public class ClientCredentialsResponse
    {
        public string Message { get; set; } = "";
        public string AccessToken { get; set; }

        public DateTime? TokenExpirationDate { get; set; }
        public bool Success { get; set; }

        public string Error { get; set; }
    }
}
