using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCMI.Admin.TCMIContentServices;
using TCMI.Admin.Models;

namespace TCMI.Admin.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        //
        // GET: /Event/
        public TCMIContentServices.TCMIContentSoapClient client = new TCMIContentSoapClient();

        public ActionResult Index()
        {
            IEnumerable<TCMI.Admin.TCMIContentServices.Event> result = client.GetAllEvents();
            return View(result);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost(EventMeta e)
        {
            string retValue = string.Empty;
            if (ModelState.IsValid)
           {
                TCMIContentServices.TCMIContentSoapClient client = new TCMIContentSoapClient();
                retValue = client.AddEvent(e.Title, e.Description, e.DateOfEvent, e.Time, e.Venue);
                ViewBag.ReturnMessage = retValue;
                return RedirectToAction("index");
           }
            ViewBag.ReturnMessage = retValue;
           return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            string retValue = string.Empty;
            TCMI.Admin.TCMIContentServices.Event e = client.GetAllEvents().FirstOrDefault(_e => _e.id.Equals(id));
            EventMeta ee = new EventMeta
            {
                id = e.id,
                Title = e.Title,
                Description = e.Description,
                DateOfEvent = e.DateOfEvent,
                Time = e.Time,
                Venue = e.Venue,
                Expired = e.Expired
            };
            ViewBag.ReturnMessage = retValue;
            return View(ee);
        }

        [HttpPost]
        public ActionResult Update(EventMeta e)
        {
            string retValue = string.Empty;
            if (ModelState.IsValid)
            {
                TCMIContentServices.TCMIContentSoapClient client = new TCMIContentSoapClient();
                retValue = client.UpdateEvent(e.id, e.Title, e.Description, e.DateOfEvent, e.Time, e.Venue, e.Expired.Value);
                ViewBag.ReturnMessage = retValue;
                return RedirectToAction("index");
            }
            ViewBag.ReturnMessage = retValue;
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            TCMI.Admin.TCMIContentServices.Event e = client.GetAllEvents().FirstOrDefault(_e => _e.id.Equals(id));
            EventMeta ee = new EventMeta
            {
                id = e.id,
                Title = e.Title,
                Description = e.Description,
                DateOfEvent = e.DateOfEvent,
                Time = e.Time,
                Venue = e.Venue,
                Expired = e.Expired
            };

            return View(ee);
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            TCMI.Admin.TCMIContentServices.Event e = client.GetAllEvents().FirstOrDefault(_e => _e.id.Equals(id));
            EventMeta ee = new EventMeta
            {
                id = e.id,
                Title = e.Title,
                Description = e.Description,
                DateOfEvent = e.DateOfEvent,
                Time = e.Time,
                Venue = e.Venue,
                Expired = e.Expired
            };

            return View(ee);
        }
        [HttpPost]
        [ActionName("Remove")]
        public ActionResult RemovePost(int id)
        {
            if (ModelState.IsValid)
            {
                client.RemoveEvent(id);
                return RedirectToAction("index");
            }

            return View();
        }


    }
}
