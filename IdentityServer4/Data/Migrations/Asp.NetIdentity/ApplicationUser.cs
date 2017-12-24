using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer.Host.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
            //PasswordHistory = new List<PasswordHistory>();
        }
        //public virtual List<PasswordHistory> PasswordHistory { get; set; }



        //public async Task AddToPasswordHistoryAsync(ApplicationUser user, string password)
        //{
        //    user.PasswordHistory.Add(new PasswordHistory() { UserId = user.Id, PasswordHash = user.PasswordHash });

        //    //await base.UpdateAsync(user).ConfigureAwait(false);

        //}

    }



}
