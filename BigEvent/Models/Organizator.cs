using Microsoft.AspNetCore.Identity;

namespace BigEvent.Models
{
    public class Organizator:IdentityUser
    {
        public string Name { get; set; }

    }
}
