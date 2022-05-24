using BigEvent.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BigEvent.Models
{
    public class Organizer
    {
        [Key]
        public int OrganizerId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Quote { get; set; }

        public string ImgLink { get; set; }

        public ApplicationDbContext IdentityUser { get; set; }

        [Required]
        string ApplicationDbContextId { get; set; }
    }
}
