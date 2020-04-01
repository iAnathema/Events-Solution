using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace EventsPortal.API.DTO
{
    public class EventDetails
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty(Required = Required.Always)]
        [MinLength(1)]
        [MaxLength(50)]
        public string Title { get; set; }
        [JsonProperty(Required = Required.Always)]
        [MinLength(1)]
        [MaxLength(1000)]
        public string Description { get; set; }
        [MinLength(1)]
        [MaxLength(1000)]
        public string Note { get; set; }
        [JsonProperty(Required = Required.Always)]
        public DateTime Date { get; set; }
        [JsonProperty(Required = Required.Always)]
        public int TypeId { get; set; }
    }
}
