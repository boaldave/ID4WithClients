using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models.Authentication
{
    public class ClientCredentials
    {
        public string ClientType { get; set; }
        public string Secret { get; set; }
    }
}
