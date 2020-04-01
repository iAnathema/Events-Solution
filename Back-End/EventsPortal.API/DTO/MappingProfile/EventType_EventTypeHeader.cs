using AutoMapper;
using EventsPortal.DAL.Models;

namespace EventsPortal.API.DTO.MappingProfile
{
    public class EventType_EventTypeHeader : Profile
    {
        public EventType_EventTypeHeader()
        {
            CreateMap<EventTypeHeader, EventType>()
                    .ForMember(d => d.TypeId, o => o.MapFrom(s => s.Id))
                    .ForMember(d => d.Title, o => o.MapFrom(s => s.Title));

            CreateMap<EventType, EventTypeHeader>()
                    .ForMember(d => d.Id, o => o.MapFrom(s => s.TypeId))
                    .ForMember(d => d.Title, o => o.MapFrom(s => s.Title));

        }
    }
}

