using System.ComponentModel.DataAnnotations;

namespace BigEvent.Models
{
    public class EventType
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }


   
}
