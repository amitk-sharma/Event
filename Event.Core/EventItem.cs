using System;

namespace Event.Core
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descripition { get; set; }
        public DateTime  EventDate { get; set; }
        public EventType EventType { get; set; }
        public string Location { get; set; }
    }
}
