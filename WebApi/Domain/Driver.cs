using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class Driver : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
