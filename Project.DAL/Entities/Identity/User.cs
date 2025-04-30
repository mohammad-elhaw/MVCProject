using Microsoft.AspNetCore.Identity;

namespace Project.DAL.Entities.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
    }
}
