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
    public class ExerciseController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Exercise
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ExerciseService(userId);
            var model = service.GetExercises();

            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExerciseCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateExerciseService();

            if (service.CreateExercise(model))
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
            var svc = CreateExerciseService();
            var model = svc.GetExerciseById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateExerciseService();
            var detail = service.GetExerciseById(id);
            
            var model =
                new ExerciseEdit
                {
                    ExerciseId = detail.ExerciseId,
                    Activity = detail.Activity,
                    TimeSpentOnActivity = detail.TimeSpentOnActivity,
                    Date = detail.Date,
                    PersonId = detail.PersonId
                };

            ViewBag.PersonId = new SelectList(_db.Persons, "PersonId", "Name", model.PersonId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ExerciseEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ExerciseId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateExerciseService();

            if (service.UpdateExercise(model))
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
            var svc = CreateExerciseService();
            var model = svc.GetExerciseById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateExerciseService();

            service.DeleteExercise(id);

            TempData["SaveResult"] = "Your entry was deleted";

            return RedirectToAction("Index");
        }


        private ExerciseService CreateExerciseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ExerciseService(userId);
            return service;
        }
    }
}