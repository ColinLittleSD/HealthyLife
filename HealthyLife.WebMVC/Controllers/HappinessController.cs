using HappyLife.Models;
using HappyLife.Models.happinessmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthyLife.WebMVC.Controllers
{
    public class HappinessController : Controller
    {
        [Authorize]
        // GET: Happiness
        public ActionResult Index()
        {
            var model = new HappinessListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HappinessCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}