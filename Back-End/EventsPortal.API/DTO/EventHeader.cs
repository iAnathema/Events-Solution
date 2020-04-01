using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace EventsPortal.API.DTO
{
    public class EventHeader
    {

        public string Id { get; set; }

        [JsonProperty(Required = Required.Always)]
        [MinLength(1)]
        [MaxLength(50)]
        public string Title { get; set; }
        [JsonProperty(Required = Required.Always)]
        public DateTime Date { get; set; }
    }
}
