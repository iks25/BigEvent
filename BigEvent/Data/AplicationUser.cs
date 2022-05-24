using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BigEvent.Data
{
    public class AplicationUser : IdentityUser
    {
        [Required]
        public UserType Type { get; set; }

    }

    public enum UserType
    {
        Organizer, BasicUser
    }
}
