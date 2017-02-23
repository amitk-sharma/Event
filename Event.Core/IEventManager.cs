using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Core
{
    public interface IEventManager
    {
        List<EventItem> GetEvents(string searchText, int pageSize, int pageId);
        List<EventItem> GetEvents();
    }
}
