using Event.Core;
using System;

namespace Event.Web.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime EventDate { get; set; }
        public EventType EventType { get; set; }
    }
}