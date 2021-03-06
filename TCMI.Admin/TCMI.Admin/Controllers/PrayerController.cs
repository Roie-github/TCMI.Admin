﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCMI.Admin.TCMIContentServices;
using TCMI.Admin.Models;

namespace TCMI.Admin.Controllers
{
    [Authorize] 
    public class PrayerController : Controller
    {
        //
        // GET: /Prayer/
        public TCMIContentServices.TCMIContentSoapClient client = new TCMIContentSoapClient();
               
        public ActionResult Index()
        {
            IEnumerable<TCMI.Admin.TCMIContentServices.Prayer> result = client.GetPrayers().ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost(PrayerMeta prayer)
        {
            string retValue = string.Empty;
            if (ModelState.IsValid)
            {
                TCMIContentServices.TCMIContentSoapClient client = new TCMIContentSoapClient();
                retValue = client.AddPrayer(prayer.Name, prayer.Email, prayer.Phone, prayer.Confidentiality, prayer.PrayerRequest);
                ViewBag.ReturnMessage = retValue;
                return RedirectToAction("index");
            }
            ViewBag.ReturnMessage = retValue;
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            TCMI.Admin.TCMIContentServices.Prayer p = client.GetPrayers().FirstOrDefault(prayer => prayer.id.Equals(id));
            PrayerMeta _p = new PrayerMeta
            {
                id = p.id,
                Name = p.Name,
                Email = p.Email,
                Phone = p.Phone,
                Confidentiality = p.Confidentiality,
                PrayerRequest = p.PrayerRequest,
                Prayed = p.Prayed,
                Answered = p.Answered,
                Received = p.Received
            };
            return View(_p);
        }

        [HttpPost]
        public ActionResult Update(PrayerMeta p)
        {
            if (ModelState.IsValid)
            {
                client.UpdatePrayer(p.id, p.Name, p.Email, p.Phone, p.Confidentiality, p.PrayerRequest, p.Prayed,p.Answered.Value);
                return RedirectToAction("index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            TCMI.Admin.TCMIContentServices.Prayer p = client.GetPrayers().FirstOrDefault(prayer => prayer.id.Equals(id));
            PrayerMeta _p = new PrayerMeta
            {
                id = p.id,
                Name = p.Name,
                Email = p.Email,
                Phone = p.Phone,
                Confidentiality = p.Confidentiality,
                PrayerRequest = p.PrayerRequest,
                Prayed = p.Prayed,
                Answered = p.Answered,
                Received = p.Received
            };
            return View(_p);
        }


        [HttpGet]
        public ActionResult Remove(int id)
        {
            TCMI.Admin.TCMIContentServices.Prayer p = client.GetPrayers().FirstOrDefault(prayer => prayer.id.Equals(id));
            PrayerMeta _p = new PrayerMeta
            {
                id = p.id,
                Name = p.Name,
                Email = p.Email,
                Phone = p.Phone,
                Confidentiality = p.Confidentiality,
                PrayerRequest = p.PrayerRequest,
                Prayed = p.Prayed,
                Answered = p.Answered,
                Received = p.Received
            };
            return View(_p);
        }

        [HttpPost]
        [ActionName("Remove")]
        public ActionResult RemovePost(int id)
        {
            if (ModelState.IsValid)
            {
                client.RemovePrayer(id);
                return RedirectToAction("index");
            }

            return View();
        }
    }
}
