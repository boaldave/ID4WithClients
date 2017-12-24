using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Host.Models
{
    public class PasswordHistory
    {

        public PasswordHistory()
        {
            CreatedDate = DateTime.Now;
        }

        public DateTime CreatedDate { get; set; }

        [Key]
        public int Id { get; set; }
        //[Key, Column(Order = 1)]
        public string PasswordHash { get; set; }


        public string UserId { get; set; }

        //public virtual ApplicationUser User { get; set; }

    }
}
