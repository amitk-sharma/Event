using Event.Core;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Event.Web.Controllers.Api
{
    [RoutePrefix("api/event")]
    public class EventController : ApiController
    {
        private IEventManager _eventService;
        public EventController( IEventManager eventService)
        {
            _eventService = eventService;
        }

        public IHttpActionResult Get(string searchText, int pageSize, int pageId)
        {
            var events = this._eventService.GetEvents(searchText, pageSize, pageId);
            return this.Ok<List<EventItem>>(events.ToList());
        }

        public IHttpActionResult Get()
        {
            var events = this._eventService.GetEvents();
            return this.Ok<List<EventItem>>(events.ToList());
        }
    }
}
