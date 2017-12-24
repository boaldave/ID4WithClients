﻿using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Host.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
