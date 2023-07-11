using Microsoft.AspNetCore.Identity;

namespace P329UserCrud.DAL.Entities
{
    public class AppUser : IdentityUser
    {
        public string? Country { get; set; }
    }
}
