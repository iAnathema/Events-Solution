using AutoMapper;
using EventsPortal.DAL.Models;

namespace EventsPortal.API.DTO.MappingProfile
{
    public class EventType_EventType : Profile
    {
        public EventType_EventType()
        {
            CreateMap<EventTypeDetails, EventType>()
                    .ForMember(d => d.TypeId, o => o.MapFrom(s => s.Id))
                    .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                    .ForMember(d => d.Description, o => o.MapFrom(s => s.Description));


            CreateMap<EventType, EventTypeDetails>()
                   .ForMember(d => d.Id, o => o.MapFrom(s => s.TypeId))
                   .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                   .ForMember(d => d.Description, o => o.MapFrom(s => s.Description));
        }
    }
}

