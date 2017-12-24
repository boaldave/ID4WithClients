

using System.Runtime.Serialization;

namespace IdentityServer.Models.AccountModels
{
    [DataContract]
    public class UserAccountResponse
    {
        [DataMember(Name = "Id")]
        public string Id { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "updateSucceeded")]
        public bool UpdateSucceeded { get; set; }
        [DataMember(Name = "createSucceeded")]
        public bool CreateSucceeded { get; set; }

        // mapped to AuthResponseBase in BI.Security. Message is input and result related, nothing system manfunction related.
        [DataMember(Name = "message")] 
        public string Message { get; set; }
        // Reserved for system errors and connection errors. There is also a success and code but those are connection specific.
        [DataMember(Name = "error")]
        public string Error { get; set; } 
    }
}
