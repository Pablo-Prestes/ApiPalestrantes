using DevEvents.API.Entities;

namespace DevEvents.API.Data
{
    public class DevEventsDbContext
    {
        public List<DevEvent> DevEvents { get; set;}


        public DevEventsDbContext()
        { 
            DevEvents = new List<DevEvent>();
        }
    } 
}
    