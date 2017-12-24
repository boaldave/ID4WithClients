


//using IdentityServer.Host.Models;
//using Microsoft.AspNetCore.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace IdentityServer.Host.Models
//{
//    public class ApplicationUserManager : UserManager<ApplicationUser>
//    {
//        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
//        {

//        }

//        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options)
//        {
//            var manager = new ApplicationUserManager(new ApplicationUserStore(new ApplicationDbContext()));

//            // Configure the application user manager
//            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
//            {
//                AllowOnlyAlphanumericUserNames = false,
//                RequireUniqueEmail = true
//            };

//            manager.PasswordValidator = new MinimumLengthValidator(6);
//            var dataProtectionProvider = options.DataProtectionProvider;

//            if (dataProtectionProvider != null)
//            {
//                manager.PasswordResetTokens = new DataProtectorTokenProvider(dataProtectionProvider.Create("PasswordReset"));
//                manager.UserConfirmationTokens = new DataProtectorTokenProvider(dataProtectionProvider.Create("ConfirmUser"));
//            }
//            return manager;
//        }

//        public override async Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
//        {
//            if (!await IsPreviousPassword(userId, newPassword))
//            {
//                return await Task.FromResult(IdentityResult.Failed("Cannot reuse old password"));

//            }
//            var store = Store as ApplicationUserStore;

//            await store.AddToPreviousPasswordsAsync(await FindByIdAsync(userId), PasswordHasher.HashPassword(newPassword));
//            return await base.ChangePasswordAsync(userId, currentPassword, newPassword);
//        }



//        public override async Task<IdentityResult> ResetPasswordAsync(string userId, string token, string newPassword)
//        {
//            if (!await IsPreviousPassword(userId, newPassword))
//            {
//                return await Task.FromResult(IdentityResult.Failed("Cannot reuse old password"));
//            }

//            var store = Store as ApplicationUserStore;
//            await store.AddToPreviousPasswordsAsync(await FindByIdAsync(userId), PasswordHasher.HashPassword(newPassword));
//            return await base.ResetPasswordAsync(userId, token, newPassword);
//        }

//        private async Task<bool> IsPreviousPassword(string userId, string newPassword)
//        {
//            var user = await FindByIdAsync(userId);

//            if (user.PreviousUserPasswords.OrderByDescending(x => x.CreateDate).
//                Select(x => x.Password).Take(5).Where(x => PasswordHasher.VerifyHashedPassword(x, newPassword) == PasswordVerificationResult.Success).
//                Count() > 0)
//            {
//                return true;
//            }
//            return false;
//        }

//    }
//}
