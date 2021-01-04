using HappyLife.Models;
using HappyLife.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthyLife.WebMVC.Controllers
{
    [Authorize]
    public class SleepController : Controller
    {
        // GET: Sleep
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SleepService(userId);
            var model = service.GetSleeps();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SleepCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSleepService();

            if (service.CreateSleep(model))
            {
                TempData["SaveResult"] = "Your entry was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Entry could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSleepService();
            var model = svc.GetSleepById(id);

            return View(model);
        }

        private SleepService CreateSleepService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SleepService(userId);
            return service;
        }
    }
}