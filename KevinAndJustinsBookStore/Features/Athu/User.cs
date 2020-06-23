using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace KevinAndJustinsBookStore.Features.Authentication
{
    public class User : IdentityUser<int>
    {
        public virtual ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
    }
}
