using System.Web.Mvc;

namespace Event.Web.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult  GetEvents()
        {
            return null;

        }

        public PartialViewResult GetEventItem()
        {
            return null;
        }

        // GET: Event/Details/5
       
    }
}
