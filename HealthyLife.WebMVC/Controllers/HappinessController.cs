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

        private HappinessService CreateHappinessService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HappinessService(userId);
            return service;
        }
    }
}