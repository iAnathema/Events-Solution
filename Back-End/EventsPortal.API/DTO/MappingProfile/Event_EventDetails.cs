using AutoMapper;
using EventsPortal.DAL.Models;

namespace EventsPortal.API.DTO.MappingProfile
{
    public class Event_EventDetails : Profile
    {
        public Event_EventDetails()
        {
            CreateMap<Event, EventDetails>()
                    .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                    .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                    .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                    .ForMember(d => d.Note, o => o.MapFrom(s => s.Note))
                    .ForMember(d => d.Date, o => o.MapFrom(s => s.Date))
                    .ForMember(d => d.TypeId, o => o.MapFrom(s => s.EventTypeId));

            CreateMap<EventDetails, Event>()
                   .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                   .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                   .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                   .ForMember(d => d.Note, o => o.MapFrom(s => s.Note))
                   .ForMember(d => d.Date, o => o.MapFrom(s => s.Date))
                   .ForMember(d => d.EventTypeId, o => o.MapFrom(s => s.TypeId));                   
        }
    }
}
