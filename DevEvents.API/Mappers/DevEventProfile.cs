using AutoMapper;
using DevEvents.API.Entities;
using DevEvents.API.Models;
using DevEvents.API.Views;

namespace DevEvents.API.Mappers
{
    public class DevEventProfile: Profile
    {
        public DevEventProfile() 
        {
            CreateMap<DevEvent, DevEventViewModel>();
            CreateMap<DevEventsPalestrantes, DevEventPalestranteViewModel>();

            CreateMap<DevEventInputModel, DevEvent>();
            CreateMap<DevEventPalestranteInputModel, DevEventsPalestrantes>();
        }
    }
}
