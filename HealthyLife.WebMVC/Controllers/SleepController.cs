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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SleepService(userId);

            service.CreateSleep(model);

            return RedirectToAction("Index");
        }
    }
}