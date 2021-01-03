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
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PersonService(userId);
            var model = service.GetPerson();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePersonService();

            if (service.CreatePerson(model))
            {
                TempData["SaveResult"] = "Your entry was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Entry could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePersonService();
            var model = svc.GetPersonById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePersonService();
            var detail = service.GetPersonById(id);
            var model =
                new PersonEdit
                {
                    PersonId = detail.PersonId,
                    Name = detail.Name,
                    Weight = detail.Weight,
                    HealthGoals = detail.HealthGoals,
                    DateStarted = detail.DateStarted
                };
            return View(model);
        }

        private PersonService CreatePersonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PersonService(userId);
            return service;
        }
    }
}