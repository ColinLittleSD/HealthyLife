using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthyLife.WebMVC.Controllers
{
    public class SleepController : Controller
    {
        // GET: Sleep
        public ActionResult Index()
        {
            return View();
        }
    }
}