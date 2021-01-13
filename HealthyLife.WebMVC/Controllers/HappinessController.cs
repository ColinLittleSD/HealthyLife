using HappyLife.Models;
using HappyLife.Models.happinessmodels;
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
    public class HappinessController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        [Authorize]
        // GET: Happiness
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HappinessService(userId);
            var model = service.GetHappinesses();

            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HappinessCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateHappinessService();

            if (service.CreateHappiness(model))
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
            var svc = CreateHappinessService();
            var model = svc.GetHappinessById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateHappinessService();
            var detail = service.GetHappinessById(id);

            var model =
                new HappinessEdit
                {
                    HappinessId = detail.HappinessId,
                    HappinessLevel = detail.HappinessLevel,
                    EmotionNotes = detail.EmotionNotes,
                    Date = detail.Date,
                    PersonId = detail.PersonId
                };

            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "Name", model.PersonId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HappinessEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.HappinessId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateHappinessService();

            if (service.UpdateHappiness(model))
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
            var svc = CreateHappinessService();
            var model = svc.GetHappinessById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateHappinessService();

            service.DeleteHappiness(id);

            TempData["SaveResult"] = "Your entry was deleted";

            return RedirectToAction("Index");
        }

        private HappinessService CreateHappinessService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HappinessService(userId);
            return service;
        }
    }
}