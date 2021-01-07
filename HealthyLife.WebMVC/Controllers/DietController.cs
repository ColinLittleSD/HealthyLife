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
    public class DietController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Diet
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DietService(userId);
            var model = service.GetDiets();

            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(_db.Exercises, "PersonId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DietCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateDietService();

            if (service.CreateDiet(model))
            {
                TempData["SaveResult"] = "Your entry was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Entry could not be created.");
            ViewBag.PersonId = new SelectList(_db.Diets, "PersonId", "Name");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateDietService();
            var model = svc.GetDietById(id);

            return View(model);
        }

        private DietService CreateDietService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DietService(userId);
            return service;
        }
    }
}