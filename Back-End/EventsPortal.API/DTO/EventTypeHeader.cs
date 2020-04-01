using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EventsPortal.API.DTO
{
    public class EventTypeHeader
    {
        public string Id { get; set; }
        [JsonProperty(Required = Required.Always)]
        [MinLength(1)]
        [MaxLength(50)]
        public string Title { get; set; }        
    }
}
