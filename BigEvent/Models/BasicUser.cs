using BigEvent.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BigEvent.Models
{
    public class BasicUser
    {

        public int BasicUserId { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(40)]
        public string Surname { get; set; }
        public string UserImageSrc { get; set; }

        public ApplicationDbContext IdentityUser { get; set; }

        [Required]
        public string ApplicationDbContextId { get; set; }
    }
}
