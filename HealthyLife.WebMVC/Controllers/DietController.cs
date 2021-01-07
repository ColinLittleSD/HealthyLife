using HappyLife.Models;
using HealthyLife.Data;
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
            var model = new DietListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}