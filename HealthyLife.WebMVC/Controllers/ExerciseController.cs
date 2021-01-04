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
    public class ExerciseController : Controller
    {
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

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateExerciseService();
            var model = svc.GetExerciseById(id);

            return View(model);
        }

        private ExerciseService CreateExerciseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ExerciseService(userId);
            return service;
        }
    }
}