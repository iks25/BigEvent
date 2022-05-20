using Microsoft.AspNetCore.Identity;

namespace BigEvent.Models
{
    public class Organizer:IdentityUser
    {
        public string Name { get; set; }

    }
}
