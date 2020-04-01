using AutoMapper;
using EventsPortal.DAL.Models;

namespace EventsPortal.API.DTO.MappingProfile
{
    public class Event_EventHeader : Profile
    {
        public Event_EventHeader()
        {
            CreateMap<Event, EventHeader>()
                    .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                    .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                    .ForMember(d => d.Date, o => o.MapFrom(s => s.Date));
        }
    }
}
