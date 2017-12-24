using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Host.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
