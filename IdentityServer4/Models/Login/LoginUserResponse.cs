using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IdentityServer.Models.Login
{
    [DataContract]
    public class LoginUserResponse
    {
        [DataMember(Name = "accessToken")]
        public string AccessToken { get; set; }

        [DataMember(Name = "accountId")]
        public string AccountId { get; set; }

        [DataMember(Name = "claims")]
        public List<dynamic> Claims { get; set; }

        [DataMember(Name = "isPasswordExpired")]
        public bool IsPasswordExpired { get; set; }

        [DataMember(Name = "loginAttemptsAllowed")]
        public int LoginAttemptsAllowed { get; set; }

        [DataMember(Name = "passwordExpirationDate")]
        public string PasswordExpirationDate { get; set; }

        [DataMember(Name = "refreshToken")]
        public string RefreshToken { get; set; }

        [DataMember(Name = "loginSucceeded")]
        public bool LoginSucceeded { get; set; } = false;

        // mapped to AuthResponseBase in BI.Security. Message is input and result related, nothing system manfunction related.
        [DataMember(Name = "message")]
        public string Message { get; set; } = ""; 
        //  Reserved for system errors and connection errors. There is also a success and code but those are connection specific.
        [DataMember(Name = "error")]
        public string Error { get; set; } = "";

    }
}