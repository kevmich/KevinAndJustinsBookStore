using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace KevinAndJustinsBookStore.Features.Authentication
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<UserRole> Users { get; set; } = new List<UserRole>();
    }
}