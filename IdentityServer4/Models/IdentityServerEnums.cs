using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class IdentityServerEnums
    {
        enum UserAccountEnum
        {
            create_success = 1,
            password_update_success = 2,
            username_update_success = 3,
            invalid_user = 4
        };

        enum LoginEnums
        {

        };
    }
}
