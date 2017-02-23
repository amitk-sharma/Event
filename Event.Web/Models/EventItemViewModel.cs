using Event.Core;
using System;

namespace Event.Web.Models
{
    public class EventItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descripition { get; set; }
        public DateTime EventDate { get; set; }
        public EventType EventType { get; set; }
        public string Location { get; set; }
    }
}