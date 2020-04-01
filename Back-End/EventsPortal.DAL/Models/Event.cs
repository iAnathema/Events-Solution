using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsPortal.DAL.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Note { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [ForeignKey("EventType")]
        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }

        

    }
}
