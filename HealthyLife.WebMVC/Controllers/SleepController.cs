using HappyLife.Models;
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
            var model = new SleepListItem[0];
            return View(model);
        }
    }
}