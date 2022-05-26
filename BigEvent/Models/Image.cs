using System.ComponentModel.DataAnnotations;

namespace BigEvent.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]

        public string Src { get; set; }
    }
}
