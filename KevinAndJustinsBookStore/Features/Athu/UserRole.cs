using Microsoft.AspNetCore.Identity;

namespace KevinAndJustinsBookStore.Features.Authentication
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}