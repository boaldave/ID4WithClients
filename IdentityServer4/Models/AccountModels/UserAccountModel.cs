using System;

namespace IdentityServer.Models.AccountModels
{
    public class UserAccountModel
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string UsernameUpdate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordUpdate { get; set; }
        public string LegacyPasswordHash { get; set; } 
    }
}
