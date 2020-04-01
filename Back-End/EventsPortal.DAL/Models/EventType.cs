using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsPortal.DAL.Models
{
    public class EventType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
