using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.Core;

namespace Event.Business
{
    public class EventManager : IEventManager
    {
        public List<EventItem> GetEvents(string searchText, int pageSize, int pageId)
        {
            pageSize = pageSize == 0 ? pageSize + 1 : pageSize;
            searchText = string.IsNullOrWhiteSpace(searchText) ? string.Empty : searchText;
            return GetEvents().Where(x => x.Title.Contains(searchText)).OrderBy(x=>x.Id).Skip((pageSize - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<EventItem> GetEvents()
        {
            return GetAllEvents().OrderBy(x => x.EventDate).Take(10).ToList();
        }

        private List<EventItem> GetAllEvents()
        {
            return new List<EventItem>
            {
                new EventItem {Id=1,Descripition="Test 1",EventDate=DateTime.Now.AddDays(1),EventType=EventType.Cultural,Title="Event T",Location="London" },
                new EventItem {Id=2,Descripition="Test 2",EventDate=DateTime.Now.AddDays(2),EventType=EventType.Educational,Title="Event Y",Location="Birmingham" },
                new EventItem {Id=3,Descripition="Test 2",EventDate=DateTime.Now.AddDays(3),EventType=EventType.Music,Title="Event N",Location="Goa" },
                new EventItem {Id=4,Descripition="Test 4",EventDate=DateTime.Now.AddDays(4),EventType=EventType.Political,Title="Event M",Location="Coventry" },
                new EventItem {Id=5,Descripition="Test 5",EventDate=DateTime.Now.AddDays(5),EventType=EventType.Research,Title="Event C",Location="Bath" },
                new EventItem {Id=6,Descripition="Test 6",EventDate=DateTime.Now.AddDays(6),EventType=EventType.Social,Title="D 1",Location="Cardiff" },
                new EventItem {Id=7,Descripition="Test 7",EventDate=DateTime.Now.AddDays(7),EventType=EventType.Sport,Title="Event F",Location="Glagow" },
                new EventItem {Id=8,Descripition="Test 8",EventDate=DateTime.Now.AddDays(8),EventType=EventType.Cultural,Title="Event J",Location="Paris" },
                new EventItem {Id=9,Descripition="Test 9",EventDate=DateTime.Now.AddDays(9),EventType=EventType.Educational,Title="Event X",Location="Geneva" },
                new EventItem {Id=10,Descripition="Test 10",EventDate=DateTime.Now.AddDays(10),EventType=EventType.Cultural,Title="Event B",Location="London" },
                new EventItem {Id=11,Descripition="Test 11",EventDate=DateTime.Now.AddDays(11),EventType=EventType.Research,Title="Event M",Location="London" },
                new EventItem {Id=12,Descripition="Test 12",EventDate=DateTime.Now.AddDays(12),EventType=EventType.Political,Title="Event R",Location="Bath" },
                new EventItem {Id=13,Descripition="Test 13",EventDate=DateTime.Now.AddDays(13),EventType=EventType.Research,Title="Event X",Location="London" },
                new EventItem {Id=14,Descripition="Test 14",EventDate=DateTime.Now.AddDays(14),EventType=EventType.Cultural,Title="Event R",Location="Reading" },
                new EventItem {Id=15,Descripition="Test 15",EventDate=DateTime.Now.AddDays(15),EventType=EventType.Music,Title="Event T",Location="London" },
                new EventItem {Id=16,Descripition="Test 16",EventDate=DateTime.Now.AddDays(16),EventType=EventType.Sport,Title="Event Y",Location="Cardiff" },
                new EventItem {Id=17,Descripition="Test 17",EventDate=DateTime.Now.AddDays(17),EventType=EventType.Cultural,Title="Event U",Location="London" },
                new EventItem {Id=18,Descripition="Test 18",EventDate=DateTime.Now.AddDays(18),EventType=EventType.Political,Title="Event H",Location="Pune" },
                new EventItem {Id=19,Descripition="Test 19",EventDate=DateTime.Now.AddDays(19),EventType=EventType.Sport,Title="Event S",Location="London" },
                new EventItem {Id=20,Descripition="Test 20",EventDate=DateTime.Now.AddDays(20),EventType=EventType.Music,Title="Event V",Location="London" },
                new EventItem {Id=21,Descripition="Test 21",EventDate=DateTime.Now.AddDays(21),EventType=EventType.Sport,Title="Event X",Location="Delhi" },
                new EventItem {Id=22,Descripition="Test 22",EventDate=DateTime.Now.AddDays(22),EventType=EventType.Educational,Title="Event J",Location="London" },
                new EventItem {Id=23,Descripition="Test 23",EventDate=DateTime.Now.AddDays(23),EventType=EventType.Research,Title="Event Z",Location="London" },
            };

        }

    }
}
