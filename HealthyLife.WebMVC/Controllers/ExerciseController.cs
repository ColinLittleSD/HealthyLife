﻿using HappyLife.Models;
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
            var model = new ExerciseListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}