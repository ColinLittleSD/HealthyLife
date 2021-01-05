using HappyLife.Models;
using HappyLife.Services;
using HealthyLife.Data;
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
        private ApplicationDbContext _db = new ApplicationDbContext();
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
            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "Name");
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

            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "Name", model.PersonId);

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSleepService();
            var model = svc.GetSleepById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSleepService();
            var detail = service.GetSleepById(id);
         
            var model =
                new SleepEdit
                {
                    SleepId = detail.SleepId,
                    HoursSlept = detail.HoursSlept,
                    WakeUpTime = detail.WakeUpTime,
                    Date = detail.Date,
                    PersonId = detail.PersonId
                };

            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "Name", model.PersonId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SleepEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SleepId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSleepService();

            if (service.UpdateSleep(model))
            {
                TempData["SaveResult"] = "Your entry was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your entry could not be updated.");

            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "Name", model.PersonId);
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSleepService();
            var model = svc.GetSleepById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSleepService();

            service.DeleteSleep(id);

            TempData["SaveResult"] = "Your entry was deleted";

            return RedirectToAction("Index");
        }

        private SleepService CreateSleepService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SleepService(userId);
            return service;
        }
        
    }
}